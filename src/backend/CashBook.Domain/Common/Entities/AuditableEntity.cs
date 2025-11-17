using CashBook.Domain.Common.Entities.Interfaces;

namespace CashBook.Domain.Common.Entities;

public abstract class AuditableEntity : IAuditableEntity
{
    public Guid Id { get; set; }
    
    public DateTimeOffset CreatedTime { get; set; }
    
    public DateTimeOffset? ModifiedTime { get; set; }
}