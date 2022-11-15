using DotNetExtensions.DomainAbstraction.Event;
using HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Repository;
using HotelResourceDdd.Core.Component.OutOfServiceComponent.Domain.OutOfServiceAggregate;
using HotelResourceDdd.Core.SharedKernel.Component.OutOfServiceComponent.OutOfServiceAggregate;
using HotelResourceDdd.Core.SharedKernel.Component.RoomComponent.RoomAggregate;
using HotelResourceDdd.Core.SharedKernel.ValueObject;
using MediatR;

namespace HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Command.NewOutOfService
{
    internal class NewOutOfServiceCommandHandler : AbstractEventHandler<NewOutOfServiceCommand>
    {
        private readonly IOutOfServiceRepository _outOfServiceRepository;

        public NewOutOfServiceCommandHandler(IOutOfServiceRepository outOfServiceRepository)
        {
            _outOfServiceRepository = outOfServiceRepository;
        }

        public override async Task<Unit> Handle(NewOutOfServiceCommand request, CancellationToken cancellationToken)
        {
            var newOutOfService = new OutOfService(
                new OutOfServiceId(request.OutOfServiceId),
                new LicenseNumber(request.LicenseNumber),
                new RoomId(request.RoomId), request.In, request.Out);

            _outOfServiceRepository.Add(newOutOfService);

            await _outOfServiceRepository.SaveAsync(newOutOfService, cancellationToken: cancellationToken);

            // Per il momento non interessa il ritorno.
            return new Unit();
        }
    }
}
