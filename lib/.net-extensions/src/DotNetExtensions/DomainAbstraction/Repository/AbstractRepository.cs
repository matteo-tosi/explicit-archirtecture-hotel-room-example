using DotNetExtensions.DomainAbstraction.Entity;
using System.Linq.Expressions;

namespace DotNetExtensions.DomainAbstraction.Repository
{
    public abstract class AbstractRepository<TAggregateRoot, TAggregateRootKey> : IRepository<TAggregateRoot, TAggregateRootKey> where TAggregateRoot : AbstractAggregateRoot<TAggregateRootKey>
    {
        public void Add(TAggregateRoot entity) => throw new NotImplementedException();
        public void AddRange(IEnumerable<TAggregateRoot> entities) => throw new NotImplementedException();
        public Task<IEnumerable<TAggregateRoot>> FindAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken = default) => throw new NotImplementedException();
        public Task<TAggregateRoot> FirstOrDefaultAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken = default) => throw new NotImplementedException();
        public Task<TAggregateRoot> LoadAsync(TAggregateRootKey key, CancellationToken cancellationToken = default) => throw new NotImplementedException();
        public void Remove(TAggregateRoot entity) => throw new NotImplementedException();
        public void RemoveRange(IEnumerable<TAggregateRoot> entities) => throw new NotImplementedException();
        public Task SaveAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken = default) => throw new NotImplementedException();
        public Task<TAggregateRoot> SingleOrDefaultAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    }
}
