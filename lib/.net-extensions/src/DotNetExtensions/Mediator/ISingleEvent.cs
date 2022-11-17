using MediatR;

namespace DotNetExtensions.Mediator
{
    public interface ISingleEvent<out TResponse> : IRequest<TResponse> { }
}
