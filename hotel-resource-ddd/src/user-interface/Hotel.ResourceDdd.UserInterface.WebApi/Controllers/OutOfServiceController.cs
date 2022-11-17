using DotNetExtensions.Mediator;
using HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Command.NewOutOfService;
using HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Query.GetOutOfServiceValidity;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.ResourceDdd.UserInterface.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OutOfServiceController : ControllerBase
    {
        private readonly ILogger<OutOfServiceController> _logger;
        private readonly IEventPublisher _eventPublisher;

        public OutOfServiceController(ILogger<OutOfServiceController> logger, IEventPublisher eventPublisher)
        {
            _logger = logger;
            _eventPublisher = eventPublisher;
        }

        [HttpGet(Name = "GetOutOfServiceValidity")]
        public async Task<GetOutOfServiceValidityQueryResponse> GetOutOfServiceValidity()
        {
            var query = new GetOutOfServiceValidityQuery(outOfServiceId: 5);
            return await _eventPublisher.Send(query);
        }

        [HttpPost(Name = "Create")]
        public async Task Create()
        {
            var command = new NewOutOfServiceCommand(outOfServiceId: 5, licenseNumber: 5, roomId: 5, start: DateTime.UtcNow, end: null);
            _ = await _eventPublisher.Send(command);
        }
    }
}