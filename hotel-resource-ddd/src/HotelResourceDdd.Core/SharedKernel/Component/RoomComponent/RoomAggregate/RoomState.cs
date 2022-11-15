using DotNetExtensions.DomainAbstraction.Enumeration;

namespace HotelResourceDdd.Core.SharedKernel.Component.RoomComponent.RoomAggregate
{
    public sealed record class RoomState : AbstractEnumeration<RoomState, short>
    {
        public readonly static RoomState Dirty = new(value: 0, "Dirty");
        public readonly static RoomState CleanToCheck = new(value: 1, "Clean but to check");
        public readonly static RoomState Ready = new(value: 2, "Ready");
        public readonly static RoomState Occupied = new(value: 3, "Occupied");
        public readonly static RoomState OutOfService = new(value: 4, "Out of service");

        private RoomState(short value, string name) : base(value, name) { }
    }
}
