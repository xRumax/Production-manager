using EndLand.Core.DTOs;
using EndLand.Transfer.ProjectsDir.Commands;
using EndLand.Transfer.ProjectsDir.Queries;
using EndLand.Transfer.RobotDeviceProgDir.Queries;
using EndLand.Transfer.RobotWaterMeterDir.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndLand.Web.Controllers
{
    [Route("api/RobotWaterMeter")]
    [ApiController]
    public class RobotWaterMeterController : Controller
    {
        private readonly IMediator _mediator;
        
        public RobotWaterMeterController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]

        public async Task<IActionResult> ListRobotWaterMeterAsync([FromQuery] ListRobotWaterMeterQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result.ToResponseDto());
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetRobotWaterMeterAsync([FromRoute] int id)
        {
            var query = new GetRobotWaterMeterQuery(){ Id = id };
            var result = await _mediator.Send(query);
            return Ok(result.ToResponseDto());
        }
    }
}