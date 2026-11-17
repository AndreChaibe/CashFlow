namespace CashFlow.Domain.Extensions;

using CashFlow.Domain.Enums;
using CashFlow.Domain.Reports.PaymentTypes;

public static class PaymentTypeExtensions
{
    public static string PaymentTypeToString(this PaymentType paymentType)
    {
        return paymentType switch
        {
            PaymentType.Cash => ResourcePaymentTypeMessages.CASH,
            PaymentType.CreditCard => ResourcePaymentTypeMessages.CREDIT_CARD,
            PaymentType.DebitCard => ResourcePaymentTypeMessages.DEBIT_CARD,
            PaymentType.ElectronicTransfer => ResourcePaymentTypeMessages.ELECTRONIC_TRANSFER,
            _ => string.Empty
        };
    }
}