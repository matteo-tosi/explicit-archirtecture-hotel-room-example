using DotNetExtensions.DomainAbstraction.Entity;
using System.Linq.Expressions;

namespace DotNetExtensions.DomainAbstraction.Repository
{
    public interface IRepository<TAggregateRoot, TAggregateRootKey> where TAggregateRoot: AbstractAggregateRoot<TAggregateRootKey>
    {
        Task<TAggregateRoot> SingleOrDefaultAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken = default);
        Task<TAggregateRoot> FirstOrDefaultAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<TAggregateRoot>> FindAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken = default);

        void Add(TAggregateRoot entity);
        void AddRange(IEnumerable<TAggregateRoot> entities);

        void Remove(TAggregateRoot entity);
        void RemoveRange(IEnumerable<TAggregateRoot> entities);


        Task SaveAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken = default);
        Task<TAggregateRoot> LoadAsync(TAggregateRootKey key, CancellationToken cancellationToken = default);
    }
}
