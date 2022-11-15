namespace DotNetExtensions.DomainAbstraction.Event
{
    public abstract class AbstractEventBase
    {
        public Guid Id { get; private set; }
        public DateTime DateOccurred { get; private set; }

        protected AbstractEventBase()
        {
            this.Id = Guid.NewGuid();
            this.DateOccurred = DateTime.UtcNow;
        }

        protected AbstractEventBase(Guid id, DateTime dateOccurred)
        {
            this.Id = id;
            this.DateOccurred = dateOccurred;
        }
    }
}
