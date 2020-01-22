using ChooseYourOwnAdventure.Domain.Model;
using FluentValidation;
using System.Linq;
using ChooseYourOwnAdventure.CrossCutting.Extensions;

namespace ChooseYourOwnAdventure.Domain.Validator
{
    public class StoryValidator : AbstractValidator<Story>
    {
        private const int MinimunLongSteps = 3;

        public StoryValidator(bool validateAllStory = true)
        {
            RuleFor(i => i.Id).NotNull().NotEmpty();
            RuleFor(i => i.Title).NotEmpty();
            if(validateAllStory) RuleFor(i => i.RootStep).NotNull().Must(ValidatePathSteps);
        }

        private bool ValidatePathSteps(Step rootStep)
        {
            var longestPath = LongestPath(rootStep, 0);

            return longestPath >= MinimunLongSteps;
        }

        private int LongestPath(Step step, int maxPath)
        {
            if (step == null) return 0;
            if (step.Choices.ListIsNullOrEmpty()) return maxPath;

            var steps = step.Choices.Select(i => i.To);

            return steps.Select(i => LongestPath(i, ++maxPath)).Max();
        }
    }
}
