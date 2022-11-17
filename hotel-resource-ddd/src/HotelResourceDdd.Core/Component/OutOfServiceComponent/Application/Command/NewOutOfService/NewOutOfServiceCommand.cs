using DotNetExtensions.CqrsAbstraction.Command;

namespace HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Command.NewOutOfService
{
    public sealed class NewOutOfServiceCommand : ICommand
    {
        public int OutOfServiceId { get; set; }
        public int LicenseNumber { get; set; }
        public int RoomId { get; set; }
        public DateTime In { get; set; }
        public DateTime? Out { get; set; }

        public NewOutOfServiceCommand(int outOfServiceId, int licenseNumber, int roomId, DateTime start, DateTime? end) : base()
        {
            this.OutOfServiceId = outOfServiceId;
            this.LicenseNumber = licenseNumber;
            this.RoomId = roomId;
            this.In = start;
            this.Out = end;
        }
    }
}
