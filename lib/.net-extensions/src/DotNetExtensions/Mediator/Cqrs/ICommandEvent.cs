using MediatR;

namespace DotNetExtensions.Mediator.Cqrs
{
    public interface ICommandEvent<out TResponse> : IRequest<TResponse> { }
}
