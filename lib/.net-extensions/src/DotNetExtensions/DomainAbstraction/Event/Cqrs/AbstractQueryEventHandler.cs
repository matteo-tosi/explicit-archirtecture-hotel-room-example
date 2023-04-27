using DotNetExtensions.Mediator.Cqrs;

namespace DotNetExtensions.DomainAbstraction.Event.Cqrs
{
    public abstract class AbstractQueryEventHandler<TRequest, TResponse> : IQueryEventHandler<TRequest, TResponse>
        where TRequest : IQueryEvent<TResponse>
    {
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}