using MediatR;

namespace DotNetExtensions.Mediator.Cqrs
{
    public interface ICommandEventHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : ICommandEvent<TResponse>
    { }
}
