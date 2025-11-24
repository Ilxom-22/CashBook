using CashBook.Domain.Entities.Cashbooks;
using CashBook.Domain.Entities.Categories;
using CashBook.Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;

namespace CashBook.Persistence.DataContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Cashbook> CashBooks => Set<Cashbook>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}