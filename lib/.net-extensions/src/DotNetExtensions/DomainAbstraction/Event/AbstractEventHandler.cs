using DotNetExtension.Mediator;
using MediatR;

namespace DotNetExtensions.DomainAbstraction.Event
{
    public abstract class AbstractEventHandler<TRequest> : IEventHandlerOneListener<TRequest>
        where TRequest : IEventOneListener
    {
        public abstract Task<Unit> Handle(TRequest request, CancellationToken cancellationToken);
    }

    public abstract class AbstractEventHandler<TRequest, TResponse> : IEventHandlerOneListener<TRequest, TResponse>
        where TRequest : IEventOneListener<TResponse>
    {
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
