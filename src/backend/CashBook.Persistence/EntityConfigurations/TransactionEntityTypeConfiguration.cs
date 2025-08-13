using CashBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transaction = CashBook.Domain.Entities.Transaction;

namespace CashBook.Persistence.EntityConfigurations;

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