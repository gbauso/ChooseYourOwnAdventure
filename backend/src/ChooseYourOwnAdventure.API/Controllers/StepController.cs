using System;
using System.Threading.Tasks;
using ChooseYourOwnAdventure.Application.Command;
using ChooseYourOwnAdventure.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChooseYourOwnAdventure.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class StepController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public StepController(IMediator mediator)
        {
            _Mediator = mediator;
        }


        [HttpPost]
        [Route("move")]
        public async Task<IActionResult> InsertMove([FromBody] InsertMoveCommand command)
        {
            return Ok(await _Mediator.Send(command));
        }

        [HttpGet]
        [Route("{stepId}/{choiceId}")]
        public async Task<IActionResult> GetStory([FromRoute] Guid stepId, [FromRoute] Guid choiceId)
        {
            var command = new GetNextStepQuery(stepId, choiceId);

            return Ok(await _Mediator.Send(command));
        }
    }
}
