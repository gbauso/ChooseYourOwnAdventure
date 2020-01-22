using ChooseYourOwnAdventure.Application.Query;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System;
using ChooseYourOwnAdventure.Application.Command;

namespace ChooseYourOwnAdventure.Test
{
    public class CommandTest
    {
        [Fact(DisplayName = "InsertMoveCommand must return valid response")]
        [Trait("Command", "Story")]
        public async Task InsertMoveCommand_Handler_ValidResponse()
        {
            var query = new InsertMoveCommandHandler(MockHelper.GetStepRepository());

            var result = await query.Handle(new InsertMoveCommand(Guid.NewGuid(),
                                                                  Guid.NewGuid(),
                                                                  Guid.NewGuid()));

            result.Should().BeTrue();
        }
    }
}
