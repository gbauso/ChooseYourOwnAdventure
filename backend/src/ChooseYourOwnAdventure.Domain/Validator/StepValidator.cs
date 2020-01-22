using ChooseYourOwnAdventure.Domain.Model;
using FluentValidation;

namespace ChooseYourOwnAdventure.Domain.Validator
{
    public class StepValidator : AbstractValidator<Step>
    {
        public StepValidator()
        {
            RuleFor(i => i.Id).NotNull().NotEmpty();
            RuleFor(i => i.Label).NotNull().NotEmpty();
        }
    }
}
