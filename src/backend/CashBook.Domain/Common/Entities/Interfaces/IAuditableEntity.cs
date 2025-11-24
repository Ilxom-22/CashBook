namespace CashBook.Domain.Common.Entities.Interfaces;

public interface IAuditableEntity
{ 
     DateTimeOffset CreatedTime { get; set; }
     
     DateTimeOffset? ModifiedTime { get; set; }
}