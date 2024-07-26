using AutoMapper;
using GloboTicket.Application.Contracts.Services;
using GloboTicket.Application.Models;
using GloboTicket.Application.Models.Http;
using GloboTicket.Domain.Entities;
using GloboTicket.Web.Common;
using GloboTicket.Web.Middleware;
using GloboTicket.Web.Models;
using GloboTicket.Web.Models.Request;
using GloboTicket.Web.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController(IMapper mapper, ITicketService ticketService) : ControllerBase
    {
        [HttpGet("Get"), TypeFilter(typeof(ValidationAttribute))]
        [ProducesResponseType(typeof(ApiResponse<TicketDataResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] int ticketId)
        {
            var result = await ticketService.Get(ticketId);

            var response = mapper.MapToApiResponse<TicketDataResponse>(result);
            response.TraceId = HttpContext.TraceIdentifier;

            if (!result.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("GetAll"), TypeFilter(typeof(ValidationAttribute))]
        [ProducesResponseType(typeof(ApiResponse<List<TicketDataResponse>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await ticketService.GetAll();

            var response = mapper.MapToApiResponse<List<TicketDataResponse>>(result);
            response.TraceId = HttpContext.TraceIdentifier;

            if (!result.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("Add")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] AddTicketRequest request)
        {
            var model = mapper.Map<AddTicketRequest, TicketModel>(request);
            var result = await ticketService.Add(model);

            var response = mapper.MapToApiResponse<int>(result);
            response.TraceId = HttpContext.TraceIdentifier;

            if (!result.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("Update")]
        [ProducesResponseType(typeof(ApiResponse<TicketDataResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] TicketModel model)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("Delete")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromQuery] int ticketId)
        {
            throw new NotImplementedException();
        }
    }
}
