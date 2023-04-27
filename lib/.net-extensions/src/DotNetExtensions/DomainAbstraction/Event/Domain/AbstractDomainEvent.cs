using DotNetExtension.Mediator.Domain;

namespace DotNetExtensions.DomainAbstraction.Event.Domain
{
    public abstract class AbstractDomainEvent : AbstractEventBase, IDomainEvent
    {
        public AbstractDomainEvent() : base()
        { }

        public AbstractDomainEvent(Guid id, DateTime dateOccurred) : base(id, dateOccurred)
        { }
    }
}
