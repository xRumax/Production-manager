using EndLand.Core.CustomExceptions;
using EndLand.Core.DTOs;
using EndLand.Core.Enums;
using EndLand.Transfer.ProjectsDir.Commands;
using EndLand.Transfer.ProjectsDir.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndLand.Web.Controllers
{
    [Route("api/Project")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> ListProjectsAsync([FromQuery] ListProjectQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result.ToResponseDto());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectAsync([FromRoute] int id)
        {
            var query = new GetProjectQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result.ToResponseDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProjectAsync([FromBody] CreateProjectCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result.ToResponseDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProjectAsync([FromRoute] int id, [FromBody] UpdateProjectCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectAsync([FromRoute]int id)
        {
            var command = new DeleteProjectCommand { Id = id };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("ExcelReport")]
        public async Task<IActionResult> GetExcelReportAsync([FromQuery] ExcelReportProjectQuery query)
        {
            var excelStream = await _mediator.Send(query);
            string fileName = $"ProjectExcelReport{DateTime.Now:yyyyMMdd}.xlsx";
            return File(excelStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}
