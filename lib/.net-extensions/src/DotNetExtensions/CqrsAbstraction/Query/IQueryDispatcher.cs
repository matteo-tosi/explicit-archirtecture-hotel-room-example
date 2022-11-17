namespace DotNetExtensions.CqrsAbstraction.Query
{
    public interface IQueryDispatcher
    {
        Task<TQueryResult> Dispatch<TQuery, TQueryResult>(TQuery query, CancellationToken cancellationToken = default) where TQuery : IQuery;
    }
}
