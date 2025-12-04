using CashBook.Domain.Entities.Cashbooks;
using CashBook.Domain.Entities.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transaction = CashBook.Domain.Entities.Transactions.Transaction;

namespace CashBook.Infrastructure.Domain.Transactions;

public class TransactionEntityTypeConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder
            .HasOne<Cashbook>(x => x.Cashbook)
            .WithMany()
            .HasForeignKey(x => x.CashbookId);

        builder
            .HasOne<Category>(x => x.Category)
            .WithMany()
            .HasForeignKey(x => x.CategoryId);
    }
}