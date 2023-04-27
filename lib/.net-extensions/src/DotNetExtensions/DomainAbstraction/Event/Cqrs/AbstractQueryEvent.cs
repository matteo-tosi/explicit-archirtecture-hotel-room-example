using DotNetExtensions.Mediator.Cqrs;

namespace DotNetExtensions.DomainAbstraction.Event.Cqrs
{
    public abstract class AbstractQueryEvent<TResponse> : AbstractEventBase, IQueryEvent<TResponse>
    {
        public AbstractQueryEvent() : base()
        { }

        public AbstractQueryEvent(Guid id, DateTime dateOccurred) : base(id, dateOccurred)
        { }
    }
}
