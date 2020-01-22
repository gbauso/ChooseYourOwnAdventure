using ChooseYourOwnAdventure.CrossCutting.Exceptions;
using ChooseYourOwnAdventure.Domain.Model;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace ChooseYourOwnAdventure.Test
{
    public class ChoiceTest
    {
        [Fact(DisplayName = "A Choice with invalid Id must trow an exception")]
        [Trait("Domain", "Choice")]
        public void Choice_WithInvalidId_MustBeInvalid()
        {
            var choice = new Choice(Guid.Empty, "answer");
            Action action = () => choice.Validate();

            action.Should().Throw<ValidationException>();
        }

        [Fact(DisplayName = "A Choice with invalid answer must trow an exception")]
        [Trait("Domain", "Choice")]
        public void Choice_WithInvalidAnswer_MustBeInvalid()
        {
            var choice = new Choice(string.Empty);
            Action action = () => choice.Validate();

            action.Should().Throw<ValidationException>();
        }

        [Fact(DisplayName = "A Choice with valid fields must not trow an exception")]
        [Trait("Domain", "Choice")]
        public void Choice_ValidFields_MustBeInvalid()
        {
            var choice = MockHelper.GetFakeStep().Choices.First();
            Action action = () => choice.Validate();

            action.Should().NotThrow();
        }
    }
}
