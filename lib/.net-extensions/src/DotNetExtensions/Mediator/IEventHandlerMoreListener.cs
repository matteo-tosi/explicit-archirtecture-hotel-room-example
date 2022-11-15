using MediatR;

namespace DotNetExtension.Mediator
{
    internal interface IEventHandlerMoreListener<in TRequest> : INotificationHandler<TRequest>
        where TRequest : INotification
    { }
}
