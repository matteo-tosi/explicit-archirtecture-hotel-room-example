using DotNetExtensions.DomainAbstraction.Event.Cqrs;
using HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Repository;
using HotelResourceDdd.Core.Component.OutOfServiceComponent.Domain.OutOfServiceAggregate;
using HotelResourceDdd.Core.SharedKernel.Component.OutOfServiceComponent.OutOfServiceAggregate;
using HotelResourceDdd.Core.SharedKernel.Component.RoomComponent.RoomAggregate;
using HotelResourceDdd.Core.SharedKernel.ValueObject;

namespace HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Command.NewOutOfService
{
    public class NewOutOfServiceCommandHandler : AbstractCommandEventHandler<NewOutOfServiceCommand, NewOutOfServiceCommandResult?>
    {
        private readonly IOutOfServiceRepository _outOfServiceRepository;

        public NewOutOfServiceCommandHandler(IOutOfServiceRepository outOfServiceRepository)
        {
            _outOfServiceRepository = outOfServiceRepository;
        }

        public override async Task<NewOutOfServiceCommandResult?> Handle(NewOutOfServiceCommand command, CancellationToken cancellationToken)
        {
            var newOutOfService = new OutOfService(
                new OutOfServiceId(command.OutOfServiceId),
                new LicenseNumber(command.LicenseNumber),
                new RoomId(command.RoomId), command.In, command.Out);

            _outOfServiceRepository.Add(newOutOfService);

            await _outOfServiceRepository.SaveAsync(newOutOfService, cancellationToken: cancellationToken);

            return null;
        }
    }
}
