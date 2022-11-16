using HotelResourceDdd.Core.Component.RoomComponent.Domain.RoomAggregate;
using HotelResourceDdd.Core.SharedKernel.Component.RoomComponent.RoomAggregate;
using HotelResourceDdd.Core.SharedKernel.ValueObject;

namespace HotelResourceDdd.Infrastructure.Persistence.EfCore.Component.RoomComponent.RoomAggregate.Model
{
    internal sealed class RoomDb
    {
        public int Id { get; set; }
        public int LicenseNumber { get; set; }
        public string? Name { get; set; }
        public RoomState? State { get; set; }

        internal Room ConvertToModel()
            => new(new RoomId(this.Id), new LicenseNumber(this.LicenseNumber), this.Name);

        internal static RoomDb ConvertByModel(Room entity)
            => new()
            {
                Id = entity.Id.Value,
                LicenseNumber = entity.LicenseNumber.Value,
                Name = entity.Name,
                State = entity.State
            };
    }
}
