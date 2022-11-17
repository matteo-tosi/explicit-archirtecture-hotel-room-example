using DotNetExtensions.CqrsAbstraction.Command;
using DotNetExtensions.CqrsAbstraction.Query;
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
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public OutOfServiceController(ILogger<OutOfServiceController> logger, ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _logger = logger;
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet(Name = "GetOutOfServiceValidity")]
        public async Task<GetOutOfServiceValidityQueryResponse> GetOutOfServiceValidity()
        {
            var query = new GetOutOfServiceValidityQuery(outOfServiceId: 5);
            return await _queryDispatcher.Dispatch<GetOutOfServiceValidityQuery, GetOutOfServiceValidityQueryResponse>(query);
        }

        [HttpPost(Name = "Create")]
        public async Task Create()
        {
            var command = new NewOutOfServiceCommand(outOfServiceId: 5, licenseNumber: 5, roomId: 5, start: DateTime.UtcNow, end: null);
            _ = await _commandDispatcher.Dispatch<NewOutOfServiceCommand, NewOutOfServiceCommandResult>(command);
        }
    }
}