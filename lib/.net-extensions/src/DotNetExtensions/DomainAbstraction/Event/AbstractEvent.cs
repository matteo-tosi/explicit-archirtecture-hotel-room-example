using DotNetExtension.Mediator;

namespace DotNetExtensions.DomainAbstraction.Event
{
    public abstract class AbstractEvent : AbstractEventBase, IEventOneListener
    {
        public AbstractEvent() : base()
        { }

        public AbstractEvent(Guid id, DateTime dateOccurred) : base(id, dateOccurred)
        { }
    }

    public abstract class AbstractEvent<TResponse> : AbstractEventBase, IEventOneListener<TResponse>
    {
        public AbstractEvent() : base()
        { }

        public AbstractEvent(Guid id, DateTime dateOccurred) : base(id, dateOccurred)
        { }
    }
}
