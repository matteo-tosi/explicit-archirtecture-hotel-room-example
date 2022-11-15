using DotNetExtensions.DomainAbstraction.Event;
using HotelResourceDdd.Core.Component.RoomComponent.Application.Repository;
using HotelResourceDdd.Core.SharedKernel.Component.OutOfServiceComponent.OutOfServiceAggregate.Event;

namespace HotelResourceDdd.Core.Component.RoomComponent.Application.Listener
{
    internal class NewOutOfServiceAddedListener : AbstractNotificationHandler<NewOutOfServiceAddedEvent>
    {
        private readonly IRoomRepository _roomRepository;

        public NewOutOfServiceAddedListener(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public override async Task Handle(NewOutOfServiceAddedEvent notification, CancellationToken cancellationToken = default)
        {
            var room = await _roomRepository.LoadAsync(notification.RoomId, cancellationToken: cancellationToken);

            room.SetOutOfServiceState(notification.Start, notification.End);

            await _roomRepository.SaveAsync(room, cancellationToken: cancellationToken);
        }
    }
}
