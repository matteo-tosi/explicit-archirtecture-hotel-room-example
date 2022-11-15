using DotNetExtensions.DomainAbstraction.Event;

namespace DotNetExtensions.DomainAbstraction.Entity
{
    public abstract class AbstractEntity
    {
        public IReadOnlyCollection<AbstractNotification> DomainEvents => _domainEvents.AsReadOnly();

        private readonly List<AbstractNotification> _domainEvents = new();

        public void AddDomainEvent(AbstractNotification domainEvent)
            => _domainEvents.Add(domainEvent);

        public void RemoveDomainEvent(AbstractNotification domainEvent)
            => _domainEvents.Remove(domainEvent);

        public void ClearDomainEvents()
            => _domainEvents.Clear();
    }
}
