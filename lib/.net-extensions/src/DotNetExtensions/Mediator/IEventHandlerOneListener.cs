using MediatR;

namespace DotNetExtension.Mediator
{
    internal interface IEventHandlerOneListener<in TRequest> : IRequestHandler<TRequest>
        where TRequest : IRequest<Unit>
    { }

    internal interface IEventHandlerOneListener<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    { }
}
