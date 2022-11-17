using DotNetExtension.Mediator;

namespace DotNetExtensions.DomainAbstraction.Event
{
    public abstract class AbstractNotificationHandler<TRequest> : IBroadcastEventHandler<TRequest>
        where TRequest : IBroadcastEvent
    {
        public abstract Task Handle(TRequest notification, CancellationToken cancellationToken = default);
    }
}
