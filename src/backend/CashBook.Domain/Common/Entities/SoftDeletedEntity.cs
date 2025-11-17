using CashBook.Domain.Common.Entities.Interfaces;

namespace CashBook.Domain.Common.Entities;

public abstract class SoftDeletedEntity : ISoftDeletedEntity
{
    public Guid Id { get; set; }
    
    public bool IsDeleted { get; set; }
    
    public DateTimeOffset? DeletedTime { get; set; }
}