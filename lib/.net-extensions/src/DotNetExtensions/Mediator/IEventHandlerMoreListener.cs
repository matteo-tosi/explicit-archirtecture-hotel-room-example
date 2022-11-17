using MediatR;

namespace DotNetExtension.Mediator
{
    public interface IEventHandlerMoreListener<in TRequest> : INotificationHandler<TRequest>
        where TRequest : INotification
    { }
}
