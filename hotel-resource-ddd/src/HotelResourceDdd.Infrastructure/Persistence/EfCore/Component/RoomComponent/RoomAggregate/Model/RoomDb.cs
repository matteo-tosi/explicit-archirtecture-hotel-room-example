using HotelResourceDdd.Core.SharedKernel.Component.RoomComponent.RoomAggregate;

namespace HotelResourceDdd.Infrastructure.Persistence.EfCore.Component.RoomComponent.RoomAggregate.Model
{
    internal sealed class RoomDb
    {
        public int Id { get; set; }
        public int LicenseNumber { get; set; }
        public string? Name { get; set; }
        public RoomState? State { get; set; }
    }
}
