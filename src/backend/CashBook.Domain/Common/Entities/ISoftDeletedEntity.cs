namespace CashBook.Domain.Common.Entities;

public interface ISoftDeletedEntity : IEntity
{
    bool IsDeleted { get; set; }
    
    DateTimeOffset? DeletedTime { get; set; }
}