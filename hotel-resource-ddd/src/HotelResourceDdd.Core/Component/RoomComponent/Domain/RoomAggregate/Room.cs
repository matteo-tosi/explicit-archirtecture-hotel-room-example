using DotNetExtensions.DomainAbstraction.Entity;
using HotelResourceDdd.Core.SharedKernel.Component.RoomComponent.RoomAggregate;
using HotelResourceDdd.Core.SharedKernel.ValueObject;

namespace HotelResourceDdd.Core.Component.RoomComponent.Domain.RoomAggregate
{
    public sealed class Room : AbstractAggregateRoot<RoomId>
    {
        public LicenseNumber LicenseNumber { get; private set; }
        public string Name { get; private set; }
        public RoomState State { get; private set; }

        public Room(RoomId id, LicenseNumber licenseNumber, string name) : base(id)
        {
            this.LicenseNumber = licenseNumber;
            this.Name = name;

            this.State = RoomState.Ready;

            this.EnsureValidState();
        }

        public void SetOutOfServiceState(DateTime start, DateTime? end)
        {
            // Se oggi è incluso, cambia lo stato della camera
            if (start > DateTime.UtcNow || end < DateTime.UtcNow)
            {
                return;
            }

            this.State = RoomState.OutOfService;
        }

        /// <summary>
        /// Permette di controllare che l'oggetto in questione sia valido, così da assicurare lo stato di validità
        /// </summary>
        private void EnsureValidState()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                throw new ArgumentNullException();
            }
        }
    }
}
