using EndLand.Core.DTOs;
using EndLand.Transfer.RobotCartonsFinishDir.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndLand.Web.Controllers
{
    [Route("api/RobotCartonsFinish")]
    [ApiController]
 
        public class RobotCartonsFinishController : Controller 
        {
            private readonly IMediator _mediator;

            public RobotCartonsFinishController(IMediator mediator)
            {
                _mediator = mediator;
            }

            [HttpGet]
            public async Task<IActionResult> ListRobotCartonsFinishAsync([FromQuery] ListRobotCartonsFinishQuery query)
            {
                var result = await _mediator.Send(query);
                return Ok(result.ToResponseDto());
            }


            [HttpGet("{id}")]
            public async Task<IActionResult> GetRobotCartonsFinishAsync([FromRoute] int id)
            {
                var query = new GetRobotCartonsFinishQuery { Id = id };
                var result = await _mediator.Send(query);
                return Ok(result.ToResponseDto());
            }
        }
    }

