namespace CashBook.Domain.Common.Entities.Interfaces;

public interface ISoftDeletedEntity
{
    bool IsDeleted { get; set; }
    
    DateTimeOffset? DeletedTime { get; set; }
}