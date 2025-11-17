namespace CashBook.Domain.Common.Entities.Interfaces;

public interface ISoftDeletedEntity : IEntity
{
    bool IsDeleted { get; set; }
    
    DateTimeOffset? DeletedTime { get; set; }
}