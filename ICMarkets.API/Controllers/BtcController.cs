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
    public class BtcController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;


        public BtcController(IMediator mediator, ILogger<BtcController> logger)
		{
            _mediator = mediator;
            _logger = logger;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<Btc>> Get()
        {
            _logger.LogInformation("GetAll method in BtcController.");

            return await _mediator.Send(new GetAllBtcQuery());

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Btc> Get(Int64 id)
        {
            _logger.LogInformation("GetByID method in BtcController.");

            return await _mediator.Send(new GetBtcByIdQuery(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BtcResponse>> CreateBtc([FromBody] CreateBtcCommand command)
        {
            var result = await _mediator.Send(command);
            _logger.LogInformation("Post method in BtcController.");
            return Ok(result);
        }

        [HttpPut("EditBtc/{id}")]
        public async Task<ActionResult> EditBtc(int id, [FromBody] EditBtcCommand command)
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
                _logger.LogInformation("Edit method in BtcController.");

                return BadRequest(exp.Message);
            }


        }


        [HttpDelete("DeleteBtc/{id}")]
        public async Task<ActionResult> DeleteBtc(int id)
        {
            try
            {
                string result = string.Empty;
                result = await _mediator.Send(new DeleteBtcCommand(id));
                return Ok(result);
            }
            catch (Exception exp)
            {
                _logger.LogInformation("Delete method in BtcController.");

                return BadRequest(exp.Message);
            }
        }
    }
}

