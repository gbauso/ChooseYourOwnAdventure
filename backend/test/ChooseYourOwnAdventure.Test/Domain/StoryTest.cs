using ChooseYourOwnAdventure.CrossCutting.Exceptions;
using ChooseYourOwnAdventure.Domain.Model;
using ChooseYourOwnAdventure.Test;
using FluentAssertions;
using System;
using Xunit;

namespace ChooseYourOwnAdventure.Test
{
    public class StoryTest
    {
        [Fact(DisplayName = "A Story with 3 or more paths must be valid")]
        [Trait("Domain", "Story")]
        public void Story_MoreThan2Paths_MustNotTrowAnException()
        {
            var story = MockHelper.GetMockStory();
            Action action = () => story.Validate();

            action.Should().NotThrow();
        }

        [Fact(DisplayName = "A Story with less than 3 paths must trow an exception")]
        [Trait("Domain", "Story")]
        public void Story_LessThan3Paths_MustTrowAnException()
        {
            var story = MockHelper.GetMockStory(false);
            Action action = () => story.Validate();

            action.Should().Throw<ValidationException>();
        }

        [Fact(DisplayName = "A Story with invalid Id must trow an exception")]
        [Trait("Domain", "Story")]
        public void Story_WithInvalidId_MustBeInvalid()
        {
            var story = new Story(Guid.Empty, "description");
            Action action = () => story.Validate();

            action.Should().Throw<ValidationException>();
        }

        [Fact(DisplayName = "A Story with invalid title must trow an exception")]
        [Trait("Domain", "Story")]
        public void Story_WithInvalidTitle_MustBeInvalid()
        {
            var story = new Story(string.Empty);
            Action action = () => story.Validate();

            action.Should().Throw<ValidationException>();
        }

        [Fact(DisplayName = "A Story with valid fields must not trow an exception")]
        [Trait("Domain", "Story")]
        public void Story_ValidFields_MustBeInvalid()
        {
            var story = MockHelper.GetFakeStory();
            Action action = () => story.Validate(false);

            action.Should().NotThrow();
        }

    }
}
