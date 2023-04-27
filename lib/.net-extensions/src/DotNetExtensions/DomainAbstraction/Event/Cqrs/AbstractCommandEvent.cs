using DotNetExtensions.Mediator.Cqrs;

namespace DotNetExtensions.DomainAbstraction.Event.Cqrs
{
    public abstract class AbstractCommandEvent<TResponse> : AbstractEventBase, ICommandEvent<TResponse>
    {
        public AbstractCommandEvent() : base()
        { }

        public AbstractCommandEvent(Guid id, DateTime dateOccurred) : base(id, dateOccurred)
        { }
    }
}
