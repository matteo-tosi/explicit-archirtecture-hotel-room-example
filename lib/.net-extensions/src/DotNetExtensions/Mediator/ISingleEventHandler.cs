using MediatR;

namespace DotNetExtensions.Mediator
{
    public interface ISingleEventHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    { }
}
