using CashBook.Domain.Common.Entities.Interfaces;

namespace CashBook.Domain.Common.Entities;

public abstract class Entity : IEntity
{
    public Guid Id { get; set; }
}