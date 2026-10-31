namespace CashFlow.Domain.Repositories.Expenses;

using CashFlow.Domain.Entities;

public interface IExpensesReadOnlyRepository
{
    Task<List<Expense>> GetAll();
    Task<Expense?> GetById(long id);
    Task<List<Expense>> FilterByMonth(DateOnly date);
}