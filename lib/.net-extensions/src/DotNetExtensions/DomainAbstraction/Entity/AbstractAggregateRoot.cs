namespace DotNetExtensions.DomainAbstraction.Entity
{
    public abstract class AbstractAggregateRoot<TKey> : AbstractEntity, IAggrateRoot
    {
        public virtual TKey Id { get; protected set; }

        protected AbstractAggregateRoot(TKey id)
        {
            this.Id = id;
        }
    }
}
