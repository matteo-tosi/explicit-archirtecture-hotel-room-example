using DotNetExtensions.Mediator;

namespace DotNetExtensions.DomainAbstraction.Event
{
    public abstract class AbstractSingleEvent<TResponse> : AbstractEventBase, ISingleEvent<TResponse>
    {
        public AbstractSingleEvent() : base()
        { }

        public AbstractSingleEvent(Guid id, DateTime dateOccurred) : base(id, dateOccurred)
        { }
    }
}
