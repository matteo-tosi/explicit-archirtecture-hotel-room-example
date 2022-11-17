using DotNetExtensions.Mediator;

namespace DotNetExtensions.DomainAbstraction.Event
{
    public abstract class AbstractSingleEventHandler<TRequest, TResponse> : ISingleEventHandler<TRequest, TResponse>
        where TRequest : ISingleEvent<TResponse>
    {
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}