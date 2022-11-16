using HotelResourceDdd.Core.Component.OutOfServiceComponent.Domain.OutOfServiceAggregate;
using HotelResourceDdd.Core.SharedKernel.Component.OutOfServiceComponent.OutOfServiceAggregate;
using HotelResourceDdd.Core.SharedKernel.Component.RoomComponent.RoomAggregate;
using HotelResourceDdd.Core.SharedKernel.ValueObject;

namespace HotelResourceDdd.Infrastructure.Persistence.EfCore.Component.OutOfServiceComponent.OutOfServiceAggregate.Model
{
    internal sealed class OutOfServiceDb
    {
        public int Id { get; set; }
        public int LicenseNumber { get; set; }
        public int RoomId { get; set; }
        public DateTime In { get; set; }
        public DateTime? Out { get; set; }

        internal OutOfService ConvertToModel()
        => new(new OutOfServiceId(this.Id), new LicenseNumber(this.LicenseNumber), new RoomId(this.RoomId), this.In, this.Out);

        internal static OutOfServiceDb ConvertByModel(OutOfService entity)
            => new()
            {
                Id = entity.Id.Value,
                LicenseNumber = entity.LicenseNumber.Value,
                RoomId = entity.RoomId.Value,
                In = entity.In,
                Out = entity.Out
            };
    }
}
