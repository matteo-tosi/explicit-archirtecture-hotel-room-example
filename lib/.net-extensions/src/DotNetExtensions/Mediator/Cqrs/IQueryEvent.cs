using MediatR;

namespace DotNetExtensions.Mediator.Cqrs
{
    public interface IQueryEvent<out TResponse> : IRequest<TResponse> { }
}
