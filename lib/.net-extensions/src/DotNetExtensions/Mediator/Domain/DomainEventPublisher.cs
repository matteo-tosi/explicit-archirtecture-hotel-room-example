using MediatR;

namespace DotNetExtensions.Mediator.Domain
{
    public class DomainEventPublisher : MediatR.Mediator, IDomainEventPublisher
    {
        public DomainEventPublisher(ServiceFactory serviceFactory)
            : base(serviceFactory)
        { }

        public new async Task Publish<TDomainEvent>(TDomainEvent notification, CancellationToken cancellationToken = default)
            where TDomainEvent : INotification
            => await base.Publish(notification, cancellationToken);
    }
}
