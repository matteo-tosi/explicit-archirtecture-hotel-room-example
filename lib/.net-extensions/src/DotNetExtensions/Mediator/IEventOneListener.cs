using MediatR;

namespace DotNetExtension.Mediator
{
    public interface IEventOneListener<out TResponse> : IRequest<TResponse> { }

    public interface IEventOneListener : IRequest { }
}
