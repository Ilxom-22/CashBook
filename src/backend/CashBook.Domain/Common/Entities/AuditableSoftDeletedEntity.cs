using CashBook.Domain.Common.Entities.Interfaces;

namespace CashBook.Domain.Common.Entities;

public abstract class AuditableSoftDeletedEntity : EntityBase, IAuditableEntity, ISoftDeletedEntity
{
    public DateTimeOffset CreatedTime { get; set; }
    
    public DateTimeOffset? ModifiedTime { get; set; }
    
    public bool IsDeleted { get; set; }
    
    public DateTimeOffset? DeletedTime { get; set; }
}