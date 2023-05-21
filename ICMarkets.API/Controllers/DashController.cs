using System;
using ICMarkets.Application.Commands;
using ICMarkets.Application.Query;
using ICMarkets.Application.Response;
using ICMarkets.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ICMarkets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;


        public DashController(IMediator mediator, ILogger<DashController> logger)
		{
            _mediator = mediator;
            _logger = logger;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<Dash>> Get()
        {
            _logger.LogInformation("GetAll method in DashController.");

            return await _mediator.Send(new GetAllDashQuery());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Dash> Get(Int64 id)
        {
            _logger.LogInformation("GetByID method in DashController.");

            return await _mediator.Send(new GetDashByIdQuery(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DashResponse>> CreateDash([FromBody] CreateDashCommand command)
        {
            var result = await _mediator.Send(command);

            _logger.LogInformation("Post method in DashController.");

            return Ok(result);
        }

        [HttpPut("EditDash/{id}")]
        public async Task<ActionResult> EditDash(int id, [FromBody] EditDashCommand command)
        {
            try
            {
                if (command.Id == id)
                {
                    var result = await _mediator.Send(command);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                _logger.LogInformation("Edit method in EthController.");

                return BadRequest(exp.Message);
            }


        }


        [HttpDelete("DeleteDash/{id}")]
        public async Task<ActionResult> DeleteDash(int id)
        {
            try
            {
                string result = string.Empty;
                result = await _mediator.Send(new DeleteDashCommand(id));
                return Ok(result);
            }
            catch (Exception exp)
            {
                _logger.LogInformation("Delete method in DashController.");

                return BadRequest(exp.Message);
            }
        }
    }
}

