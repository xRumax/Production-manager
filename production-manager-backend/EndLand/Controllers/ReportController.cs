using EndLand.Core.DTOs;
using EndLand.Transfer.ReportsDir.Commands;
using EndLand.Transfer.ReportsDir.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndLand.Web.Controllers
{
    [Route("api/Report")]
    [ApiController]
    public class ReportController : Controller
    {
        private readonly IMediator _mediator;

        public ReportController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> ListReportAsync([FromQuery] ListReportQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result.ToResponseDto());
        }
        
        [HttpGet("{imei}")]

        public async Task<IActionResult> GetReportAsync([FromRoute] string imei)
        {
            var query = new GetReportQuery(){ Imei = imei };
            var result = await _mediator.Send(query);
            return Ok(result.ToResponseDto());
        }

        [HttpDelete("{imei}/{createdAt}")]
        public async Task<IActionResult> DeleteReportAsync([FromRoute] string imei, [FromRoute] DateTime createdAt)
        {
            var command = new DeleteReportCommand { Imei = imei, CreatedAt = createdAt};
            await _mediator.Send(command);
            return Ok();
        }


        [HttpGet("ExcelReport")]
        public async Task<IActionResult> GetExcelReportAsync([FromQuery] ExcelReportReportQuery query)
        {
            var excelStream = await _mediator.Send(query);
            string fileName = $"ReportExcelReport{DateTime.Now:yyyyMMdd}.xlsx";
            return File(excelStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
        
    }
}
