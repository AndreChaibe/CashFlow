namespace CashFlow.Domain.Repositories.Expenses;

using CashFlow.Domain.Entities;

public interface IExpensesUpdateOnlyRepository
{
    Task<Expense?> GetById(long id);
    void Update(Expense expense);
}