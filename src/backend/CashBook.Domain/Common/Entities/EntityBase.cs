using CashBook.Domain.Common.Events;

namespace CashBook.Domain.Common.Entities;

public abstract class EntityBase
{
    public Guid Id { get; } = Guid.NewGuid();

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
    
    public override bool Equals(object? obj)
    {
        if (obj is not EntityBase other) 
            return false;

        if (ReferenceEquals(this, other)) 
            return true;

        if (Id == Guid.Empty || other.Id == Guid.Empty) 
            return false;

        return Id == other.Id;
    }

    public override int GetHashCode() => Id.GetHashCode();
}