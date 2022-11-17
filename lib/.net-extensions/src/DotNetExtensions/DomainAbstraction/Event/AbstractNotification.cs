using DotNetExtension.Mediator;

namespace DotNetExtensions.DomainAbstraction.Event
{
    public abstract class AbstractNotification : AbstractEventBase, IBroadcastEvent
    {
        public AbstractNotification() : base()
        { }

        public AbstractNotification(Guid id, DateTime dateOccurred) : base(id, dateOccurred)
        { }
    }
}
