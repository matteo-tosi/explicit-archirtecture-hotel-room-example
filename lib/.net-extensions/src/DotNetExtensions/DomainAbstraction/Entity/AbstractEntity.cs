using DotNetExtensions.DomainAbstraction.Event.Domain;

namespace DotNetExtensions.DomainAbstraction.Entity
{
    public abstract class AbstractEntity
    {
        public IReadOnlyCollection<AbstractDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        private readonly List<AbstractDomainEvent> _domainEvents = new();

        public void AddDomainEvent(AbstractDomainEvent domainEvent)
            => _domainEvents.Add(domainEvent);

        public void RemoveDomainEvent(AbstractDomainEvent domainEvent)
            => _domainEvents.Remove(domainEvent);

        public void ClearDomainEvents()
            => _domainEvents.Clear();
    }
}
