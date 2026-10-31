namespace CashFlow.Application.UseCases.Expenses.Reports.Excel;

using CashFlow.Communication.Enums;
using CashFlow.Domain.Reports.ReportGeneration;
using CashFlow.Domain.Reports.PaymentTypes;
using CashFlow.Domain.Repositories.Expenses;
using ClosedXML.Excel;

public class GenerateExpensesReportExcelUseCase : IGenerateExpensesReportExcelUseCase
{
  private readonly IExpensesReadOnlyRepository _repository;

  public GenerateExpensesReportExcelUseCase(IExpensesReadOnlyRepository repository)
  {
    _repository = repository;
  }

  public async Task<byte[]> Execute(DateOnly month)
  {
    var expenses = await _repository.FilterByMonth(month);
    if (expenses.Count == 0) return [];

    using var workbook = new XLWorkbook();

    workbook.Author = "André Chaibe";
    workbook.Style.Font.FontSize = 18;
    workbook.Style.Font.FontName = "Times New Roman";

    var worksheet = workbook.Worksheets.Add(month.ToString("Y"));

    InsertHeader(worksheet);

    var row = 2;
    foreach (var expense in expenses)
    {
      worksheet.Cell($"A{row}").Value = expense.Title;
      worksheet.Cell($"B{row}").Value = expense.Date;
      worksheet.Cell($"C{row}").Value = ConvertPaymentType((PaymentType)expense.PaymentType);

      worksheet.Cell($"D{row}").Value = expense.Amount;
      worksheet.Cell($"D{row}").Style.NumberFormat.Format = "-#,##0.00";

      worksheet.Cell($"E{row}").Value = expense.Description;

      row++;
    }

    worksheet.Columns().AdjustToContents();

    var file = new MemoryStream();
    workbook.SaveAs(file);

    return file.ToArray();
  }

  private string ConvertPaymentType(PaymentType payment)
  {
    return payment switch
    {
      PaymentType.Cash => ResourcePaymentTypeMessages.CASH,
      PaymentType.CreditCard => ResourcePaymentTypeMessages.CREDIT_CARD,
      PaymentType.DebitCard => ResourcePaymentTypeMessages.DEBIT_CARD,
      PaymentType.ElectronicTransfer => ResourcePaymentTypeMessages.ELECTRONIC_TRANSFER,
      _ => string.Empty
    };
  }

  private void InsertHeader(IXLWorksheet worksheet)
  {
    worksheet.Cell("A1").Value = ResourceReportGenerationMessages.TITLE;
    worksheet.Cell("B1").Value = ResourceReportGenerationMessages.DATE;
    worksheet.Cell("C1").Value = ResourceReportGenerationMessages.PAYMENT_TYPE;
    worksheet.Cell("D1").Value = ResourceReportGenerationMessages.AMOUNT;
    worksheet.Cell("E1").Value = ResourceReportGenerationMessages.DESCRIPTION;

    worksheet.Cells("A1:E1").Style.Font.Bold = true;
    worksheet.Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.FromHtml("#d17979");

    worksheet.Cell("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
    worksheet.Cell("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
    worksheet.Cell("C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
    worksheet.Cell("E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

    worksheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
  }
}