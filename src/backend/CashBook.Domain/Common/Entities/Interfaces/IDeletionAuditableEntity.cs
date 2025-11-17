namespace CashBook.Domain.Common.Entities.Interfaces;

public interface IDeletionAuditableEntity
{
    Guid? DeletedByUserId { get; set; }
}