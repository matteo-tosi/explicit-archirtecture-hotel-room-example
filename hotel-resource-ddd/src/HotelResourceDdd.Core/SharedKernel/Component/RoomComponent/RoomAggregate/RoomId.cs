using DotNetExtensions.DomainAbstraction.Identity;

namespace HotelResourceDdd.Core.SharedKernel.Component.RoomComponent.RoomAggregate
{
    public sealed record class RoomId : AbstractNumberIdenty<int>
    {
        public RoomId(int id) : base(id)
        { }
    }
}
