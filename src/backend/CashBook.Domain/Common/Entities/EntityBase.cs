using CashBook.Domain.Common.Entities.Interfaces;
using CashBook.Domain.Common.Events;

namespace CashBook.Domain.Common.Entities;

public abstract class EntityBase : IEntity
{
    public Guid Id { get; set; }

    private readonly List<EventBase> _domainEvents = new();
    
    public IReadOnlyCollection<EventBase> DomainEvents => _domainEvents.AsReadOnly();
    
    public void AddDomainEvent(EventBase domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(EventBase domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}