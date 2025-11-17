namespace CashBook.Domain.Common.Entities.Interfaces;

public interface ICreationAuditableEntity
{
    Guid? CreatedByUserId { get; set; }
}