using EndLand.Core.CustomExceptions;
using EndLand.Core.DTOs;
using EndLand.Core.Enums;
using EndLand.Transfer.ProjectsDir.Commands;
using EndLand.Transfer.ProjectsDir.Queries;
using EndLand.Transfer.RobotConfigurationDir.Queries;
using EndLand.Transfer.RobotDevicesProgDir.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndLand.Web.Controllers
{
    [Route("api/RobotConfiguration")]
    [ApiController]
    public class RobotConfigurationController : Controller
    {
        private readonly IMediator _mediator;

        public RobotConfigurationController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> ListRobotConfigurationAsync([FromQuery] ListRobotConfigurationQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result.ToResponseDto());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRobotConfigurationAsync([FromRoute] int id)
        {
            var query = new GetRobotConfigurationQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result.ToResponseDto());
        }
        
    }
}

