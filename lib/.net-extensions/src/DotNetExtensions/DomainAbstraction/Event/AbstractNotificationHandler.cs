using DotNetExtension.Mediator;

namespace DotNetExtensions.DomainAbstraction.Event
{
    public abstract class AbstractNotificationHandler<TRequest> : IEventHandlerMoreListener<TRequest>
        where TRequest : IEventMoreListener
    {
        public abstract Task Handle(TRequest notification, CancellationToken cancellationToken = default);
    }
}
