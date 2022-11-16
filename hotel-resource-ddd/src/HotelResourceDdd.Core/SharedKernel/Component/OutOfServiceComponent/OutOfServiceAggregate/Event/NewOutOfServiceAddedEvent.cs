using DotNetExtensions.DomainAbstraction.Event;
using HotelResourceDdd.Core.SharedKernel.Component.RoomComponent.RoomAggregate;
using HotelResourceDdd.Core.SharedKernel.ValueObject;

namespace HotelResourceDdd.Core.SharedKernel.Component.OutOfServiceComponent.OutOfServiceAggregate.Event
{
    public class NewOutOfServiceAddedEvent : AbstractNotification
    {
        public LicenseNumber LicenseNumber { get; private set; }
        public OutOfServiceId OutOfServiceId { get; private set; }
        public RoomId RoomId { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime? End { get; private set; }

        public NewOutOfServiceAddedEvent(LicenseNumber licenseNumber, OutOfServiceId outOfServiceId, RoomId roomId, DateTime start, DateTime? end)
        {
            this.LicenseNumber = licenseNumber;
            this.OutOfServiceId = outOfServiceId;
            this.RoomId = roomId;
            this.Start = start;
            this.End = end;
        }
    }
}
