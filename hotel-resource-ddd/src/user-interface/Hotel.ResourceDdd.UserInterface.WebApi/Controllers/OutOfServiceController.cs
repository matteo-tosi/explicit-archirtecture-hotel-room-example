using HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Command.NewOutOfService;
using HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Query.GetOutOfServiceValidity;
using HotelResourceDdd.Core.Port.EventManager;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.ResourceDdd.UserInterface.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OutOfServiceController : ControllerBase
    {
        private readonly ILogger<OutOfServiceController> _logger;
        private readonly IEventManager _eventManager;

        public OutOfServiceController(ILogger<OutOfServiceController> logger, IEventManager eventManager)
        {
            _logger = logger;
            _eventManager = eventManager;
        }

        [HttpGet(Name = "GetOutOfServiceValidity")]
        public async Task<GetOutOfServiceValidityQueryResponse> GetOutOfServiceValidity()
        {
            var query = new GetOutOfServiceValidityQuery(outOfServiceId: 5);
            return await _eventManager.Send(query);
        }

        [HttpPost(Name = "Create")]
        public void Create()
        {
            var command = new NewOutOfServiceCommand(outOfServiceId: 5, licenseNumber: 5, roomId: 5, start: DateTime.UtcNow, end: null);
            _ = _eventManager.Send(command);
        }
    }
}