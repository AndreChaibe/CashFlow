namespace CashFlow.Infrastructure.DataAccess;

using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

internal class CashFlowDbContext : DbContext
{
    public CashFlowDbContext(DbContextOptions options) : base(options) {}

    public DbSet<Expense> Expenses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Expense>().ToTable("expenses");
    }
}