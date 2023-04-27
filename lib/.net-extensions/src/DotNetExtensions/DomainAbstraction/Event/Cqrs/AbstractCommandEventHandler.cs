using DotNetExtensions.Mediator.Cqrs;

namespace DotNetExtensions.DomainAbstraction.Event.Cqrs
{
    public abstract class AbstractCommandEventHandler<TRequest, TResponse> : ICommandEventHandler<TRequest, TResponse>
        where TRequest : ICommandEvent<TResponse>
    {
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}