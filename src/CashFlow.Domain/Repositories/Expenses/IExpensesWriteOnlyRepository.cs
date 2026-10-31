namespace CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Entities;

public interface IExpensesWriteOnlyRepository
{
    Task add(Expense expense);
    Task<bool> Delete(long id);
}