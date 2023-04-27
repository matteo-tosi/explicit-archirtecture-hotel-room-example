using MediatR;

namespace DotNetExtensions.Mediator.Cqrs
{
    public class CqrsEventPublisher : MediatR.Mediator, ICqrsEventPublisher
    {
        public CqrsEventPublisher(ServiceFactory serviceFactory)
            : base(serviceFactory)
        { }

        public async Task<TResponse> Send<TResponse>(IQueryEvent<TResponse> request, CancellationToken cancellationToken = default)
            => await base.Send(request, cancellationToken);

        public async Task Send<TResponse>(ICommandEvent<TResponse> request, CancellationToken cancellationToken = default)
            => await base.Send(request, cancellationToken);
    }
}
