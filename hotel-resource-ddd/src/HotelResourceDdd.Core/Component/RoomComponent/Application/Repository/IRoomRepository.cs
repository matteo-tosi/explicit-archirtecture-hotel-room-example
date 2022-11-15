using DotNetExtensions.DomainAbstraction.Repository;
using HotelResourceDdd.Core.SharedKernel.Component.RoomComponent.RoomAggregate;

namespace HotelResourceDdd.Core.Component.RoomComponent.Application.Repository
{
    public interface IRoomRepository : IRepository<Domain.RoomAggregate.Room, RoomId>
    { }
}
