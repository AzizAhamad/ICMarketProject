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
    public class EthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;


        public EthController(IMediator mediator, ILogger<EthController> logger)
		{
            _mediator = mediator;
            _logger = logger;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<Eth>> Get()
        {
            _logger.LogInformation("GetAll method in EthController.");

            return await _mediator.Send(new GetAllEthQuery());

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Eth> Get(Int64 id)
        {
            _logger.LogInformation("GetByID method in EthController.");

            return await _mediator.Send(new GetEthByIdQuery(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EthResponse>> CreateEth([FromBody] CreateEthCommand command)
        {
            var result = await _mediator.Send(command);

            _logger.LogInformation("Post method in EthController.");

            return Ok(result);
        }

        [HttpPut("EditEth/{id}")]
        public async Task<ActionResult> EditEth(int id, [FromBody] EditEthCommand command)
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


        [HttpDelete("DeleteEth/{id}")]
        public async Task<ActionResult> DeleteEth(int id)
        {
            try
            {
                string result = string.Empty;
                result = await _mediator.Send(new DeleteEthCommand(id));
                return Ok(result);
            }
            catch (Exception exp)
            {
                _logger.LogInformation("Delete method in EthController.");

                return BadRequest(exp.Message);
            }
        }
    }
}

