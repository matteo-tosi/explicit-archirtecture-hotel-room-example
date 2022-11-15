namespace HotelResourceDdd.Infrastructure.Persistence.EfCore.Component.OutOfServiceComponent.OutOfServiceAggregate.Model
{
    internal sealed class OutOfServiceDb
    {
        public int Id { get; set; }
        public int LicenseNumber { get; set; }
        public int RoomId { get; set; }
        public DateTime In { get; set; }
        public DateTime? Out { get; set; }
    }
}
