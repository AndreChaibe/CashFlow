namespace CashFlow.Infrastructure.DataAccess;

using CashFlow.Domain.Repositories;

internal class UnitOfWork(CashFlowDbContext dbContext) : IUnitOfWork
{
    public async Task Commit() => await dbContext.SaveChangesAsync();
}