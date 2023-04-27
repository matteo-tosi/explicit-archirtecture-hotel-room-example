using DotNetExtensions.Mediator.Cqrs;
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
        private readonly ICqrsEventPublisher _cqrsEventPublisher;

        public OutOfServiceController(ILogger<OutOfServiceController> logger, ICqrsEventPublisher cqrsEventPublisher)
        {
            _logger = logger;
            _cqrsEventPublisher = cqrsEventPublisher;
        }

        [HttpGet(Name = "GetOutOfServiceValidity")]
        public async Task<GetOutOfServiceValidityQueryResponse> GetOutOfServiceValidity()
        {
            var query = new GetOutOfServiceValidityQuery(outOfServiceId: 5);
            return await _cqrsEventPublisher.Send(query);
        }

        [HttpPost(Name = "Create")]
        public async Task Create()
        {
            var command = new NewOutOfServiceCommand(outOfServiceId: 5, licenseNumber: 5, roomId: 5, start: DateTime.UtcNow, end: null);
            _ = await _cqrsEventPublisher.Send(command);
        }
    }
}