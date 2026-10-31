namespace CashFlow.Application.UseCases.Expenses.GetAll;

using CashFlow.Communication.Responses;

public interface IGetAllExpenseUseCase
{
    Task<ResponseExpensesJson> Execute();
}