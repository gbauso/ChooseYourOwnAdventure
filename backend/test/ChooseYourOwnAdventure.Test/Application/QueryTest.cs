using ChooseYourOwnAdventure.Application.Query;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ChooseYourOwnAdventure.Test
{
    public class QueryTest
    {
        [Fact(DisplayName = "GetStories must return valid response")]
        [Trait("Query", "Story")]
        public async Task GetStoriesQuery_Handler_ValidResponse()
        {
            var query = new GetStoriesHandler(MockHelper.GetStoryRepository(),
                                              MockHelper.GetMapper());

            var result = await query.Handle(new GetStoriesQuery());

            result.Should().NotBeNull().And.NotBeEmpty();
        }

        [Fact(DisplayName = "GetStory must return valid response")]
        [Trait("Query", "Story")]
        public async Task GetStoryQuery_Handler_ValidResponse()
        {
            var query = new GetStoryHandler(MockHelper.GetStoryRepository(),
                                              MockHelper.GetMapper());

            var result = await query.Handle(new GetStoryQuery(Guid.NewGuid()));

            result.Should().NotBeNull();
        }

        [Fact(DisplayName = "GetStoryExecution must return valid response")]
        [Trait("Query", "Story")]
        public async Task GetStoryExecutionQuery_Handler_ValidResponse()
        {
            var query = new GetStoryExecutionHandler(MockHelper.GetStepRepository(),
                                                     MockHelper.GetStoryRepository(),
                                                     MockHelper.GetMapper());

            var result = await query.Handle(new GetStoryExecutionQuery(Guid.NewGuid(), Guid.NewGuid()));

            result.Should().NotBeNull();
        }

        [Fact(DisplayName = "GetNextStep must return valid response")]
        [Trait("Query", "Story")]
        public async Task GetNextStepQuery_Handler_ValidResponse()
        {
            var query = new GetNextStepHandler(MockHelper.GetStepRepository(),
                                               MockHelper.GetMapper());

            var result = await query.Handle(new GetNextStepQuery(Guid.NewGuid(), Guid.NewGuid()));

            result.Should().NotBeNull();
        }
    }
}
