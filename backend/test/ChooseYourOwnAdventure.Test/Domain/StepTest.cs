using ChooseYourOwnAdventure.CrossCutting.Exceptions;
using ChooseYourOwnAdventure.Domain.Model;
using FluentAssertions;
using System;
using Xunit;

namespace ChooseYourOwnAdventure.Test
{
    public class StepTest
    {
        [Fact(DisplayName = "A Step with invalid Id must trow an exception")]
        [Trait("Domain", "Step")]
        public void Step_WithInvalidId_MustBeInvalid()
        {
            var step = new Step(Guid.Empty, "question", false);
            Action action = () => step.Validate();

            action.Should().Throw<ValidationException>();
        }

        [Fact(DisplayName = "A Step with invalid label must trow an exception")]
        [Trait("Domain", "Step")]
        public void Step_WithInvalidLabel_MustBeInvalid()
        {
            var step = new Step(string.Empty, false);
            Action action = () => step.Validate();

            action.Should().Throw<ValidationException>();
        }

        [Fact(DisplayName = "A Step with valid fields must not trow an exception")]
        [Trait("Domain", "Step")]
        public void Step_ValidFields_MustBeInvalid()
        {
            var step = MockHelper.GetFakeStep();
            Action action = () => step.Validate();

            action.Should().NotThrow();
        }
    }
}
