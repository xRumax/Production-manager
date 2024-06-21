using EndLand.Core.DTOs;
using EndLand.Transfer.ProjectsDir.Queries;
using EndLand.Transfer.RobotCartonsInitialDir.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndLand.Web.Controllers
{
    [Route("api/RobotCartonsInitial")]
    [ApiController]
    public class RobotCartonsInitialController : Controller
    {
        private readonly IMediator _mediator;

        public RobotCartonsInitialController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> ListRobotCartonsInitialAsync([FromQuery] ListRobotCartonsInitialQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result.ToResponseDto());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRobotCartonsInitialAsync([FromRoute] int id)
        {
            var query = new GetRobotCartonsInitialQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result.ToResponseDto());
        }
    }
}
