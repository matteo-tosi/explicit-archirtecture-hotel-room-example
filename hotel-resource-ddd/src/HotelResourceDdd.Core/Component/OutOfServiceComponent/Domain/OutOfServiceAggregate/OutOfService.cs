using DotNetExtensions.DomainAbstraction.Entity;
using HotelResourceDdd.Core.SharedKernel.Component.OutOfServiceComponent.OutOfServiceAggregate;
using HotelResourceDdd.Core.SharedKernel.Component.OutOfServiceComponent.OutOfServiceAggregate.Event;
using HotelResourceDdd.Core.SharedKernel.Component.RoomComponent.RoomAggregate;
using HotelResourceDdd.Core.SharedKernel.ValueObject;

namespace HotelResourceDdd.Core.Component.OutOfServiceComponent.Domain.OutOfServiceAggregate
{
    public sealed class OutOfService : AbstractAggregateRoot<OutOfServiceId>
    {
        public LicenseNumber LicenseNumber { get; private set; }
        public RoomId RoomId { get; private set; }
        public DateTime In { get; private set; }
        public DateTime? Out { get; private set; }

        public OutOfService(OutOfServiceId id, LicenseNumber licenseNumber, RoomId roomId, DateTime start, DateTime? end) : base(id)
        {
            this.Id = id;
            this.LicenseNumber = licenseNumber;
            this.RoomId = roomId;
            this.In = start;
            this.Out = end;

            this.EnsureValidState();

            this.AddDomainEvent(new NewOutOfServiceAddedEvent(licenseNumber, id, roomId, start, end));
        }

        /// <summary>
        /// Permette di controllare che l'oggetto in questione sia valido, così da assicurare lo stato di validità
        /// </summary>
        private void EnsureValidState()
        {
            if (this.Out != null && this.In > this.Out)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
