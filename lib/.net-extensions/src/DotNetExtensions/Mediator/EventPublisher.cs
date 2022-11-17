using MediatR;

namespace DotNetExtensions.Mediator
{
    public class EventPublisher : MediatR.Mediator, IEventPublisher
    {
        public EventPublisher(ServiceFactory serviceFactory)
            : base(serviceFactory)
        { }

        public new async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
            => await base.Send(request, cancellationToken);

        public new async Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
            where TNotification : INotification
            => await base.Publish(notification, cancellationToken);
    }
}
