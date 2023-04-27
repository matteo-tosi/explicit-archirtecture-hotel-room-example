using DotNetExtension.Mediator.Domain;

namespace DotNetExtensions.DomainAbstraction.Event.Domain
{
    public abstract class AbstractDomainEventHandler<TRequest> : IDomainEventHandler<TRequest>
        where TRequest : IDomainEvent
    {
        public abstract Task Handle(TRequest notification, CancellationToken cancellationToken = default);
    }
}
