using System;
using System.Threading.Tasks;
using ChooseYourOwnAdventure.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChooseYourOwnAdventure.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public StoryController(IMediator mediator)
        {
            _Mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetStories()
        {
            var command = new GetStoriesQuery();

            return Ok(await _Mediator.Send(command));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStory([FromRoute] Guid id)
        {
            var command = new GetStoryQuery(id);

            return Ok(await _Mediator.Send(command));
        }

        [HttpGet]
        [Route("moves/{storyId}/{sessionId}")]
        public async Task<IActionResult> GetMoves([FromRoute] GetStoryExecutionQuery command)
        {
            return Ok(await _Mediator.Send(command));
        }
    }
}
