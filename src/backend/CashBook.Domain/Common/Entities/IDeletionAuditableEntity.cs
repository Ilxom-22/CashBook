namespace CashBook.Domain.Common.Entities;

public interface IDeletionAuditableEntity
{
    Guid? DeletedByUserId { get; set; }
}