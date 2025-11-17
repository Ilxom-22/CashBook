namespace CashBook.Domain.Common.Entities.Interfaces;

public interface IModificationAuditableEntity
{
    Guid? ModifiedByUserId { get; set; }
}