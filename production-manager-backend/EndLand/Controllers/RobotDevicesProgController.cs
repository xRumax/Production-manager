using EndLand.Core.DTOs;
using EndLand.Transfer.ProjectsDir.Commands;
using EndLand.Transfer.RobotDeviceProgDir.Queries;
using EndLand.Transfer.RobotDevicesProgDir.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndLand.Web.Controllers
{
    [Route("api/RobotDevicesProg")]
    [ApiController]
    public class RobotDevicesProgController : Controller
    {
        private readonly IMediator _mediator;

        public RobotDevicesProgController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListRobotDevicesProgAsync([FromQuery] ListRobotDevicesProgQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result.ToResponseDto());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRobotDevicesAsync([FromRoute] int id)
        {
            var query = new GetRobotDeviceQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result.ToResponseDto());
        }


    }
}
