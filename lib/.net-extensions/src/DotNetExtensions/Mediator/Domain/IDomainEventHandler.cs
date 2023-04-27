using MediatR;

namespace DotNetExtension.Mediator.Domain
{
    public interface IDomainEventHandler<in TRequest> : INotificationHandler<TRequest>
        where TRequest : IDomainEvent
    { }
}
