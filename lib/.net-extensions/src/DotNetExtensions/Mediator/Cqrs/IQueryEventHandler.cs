using MediatR;

namespace DotNetExtensions.Mediator.Cqrs
{
    public interface IQueryEventHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IQueryEvent<TResponse>
    { }
}
