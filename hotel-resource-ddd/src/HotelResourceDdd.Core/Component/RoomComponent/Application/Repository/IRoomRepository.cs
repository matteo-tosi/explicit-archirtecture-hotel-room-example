using DotNetExtensions.DomainAbstraction.Repository;
using HotelResourceDdd.Core.Component.RoomComponent.Domain.RoomAggregate;
using HotelResourceDdd.Core.SharedKernel.Component.RoomComponent.RoomAggregate;

namespace HotelResourceDdd.Core.Component.RoomComponent.Application.Repository
{
    public interface IRoomRepository : IRepository<Room, RoomId>
    { }
}
