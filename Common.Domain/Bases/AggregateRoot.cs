using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Domain.Bases;

public class AggregateRoot : BaseEntity
{
    private readonly List<BaseDomainEvent> _domainEvents = new();

    [NotMapped]
    public List<BaseDomainEvent> DomainEvents => _domainEvents;

    public void AddDomainEvent(BaseDomainEvent eventItem) => _domainEvents.Add(eventItem);

    public void RemoveDomainEvent(BaseDomainEvent eventItem) => _domainEvents?.Remove(eventItem);
}
