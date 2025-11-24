using CashBook.Domain.Common.Entities.Interfaces;

namespace CashBook.Domain.Common.Entities;

public abstract class SoftDeletedEntity : EntityBase, ISoftDeletedEntity
{
    public bool IsDeleted { get; set; }
    
    public DateTimeOffset? DeletedTime { get; set; }
}