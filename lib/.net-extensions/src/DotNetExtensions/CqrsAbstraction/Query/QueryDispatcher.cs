using Microsoft.Extensions.DependencyInjection;

namespace DotNetExtensions.CqrsAbstraction.Query
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TQueryResult> Dispatch<TQuery, TQueryResult>(TQuery query, CancellationToken cancellation = default)
            where TQuery : IQuery
        {
            var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TQueryResult>>();
            return await handler.Handle(query, cancellation);
        }
    }
}
