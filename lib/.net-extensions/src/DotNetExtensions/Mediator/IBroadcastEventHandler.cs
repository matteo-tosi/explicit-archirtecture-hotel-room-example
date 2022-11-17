using MediatR;

namespace DotNetExtension.Mediator
{
    public interface IBroadcastEventHandler<in TRequest> : INotificationHandler<TRequest>
        where TRequest : INotification
    { }
}
