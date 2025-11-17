namespace CashBook.Domain.Common.Entities.Interfaces;

public interface IAuditableEntity : IEntity
{ 
     DateTimeOffset CreatedTime { get; set; }
     
     DateTimeOffset? ModifiedTime { get; set; }
}