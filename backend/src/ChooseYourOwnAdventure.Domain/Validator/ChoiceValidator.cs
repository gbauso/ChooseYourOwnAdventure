using ChooseYourOwnAdventure.Domain.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChooseYourOwnAdventure.Domain.Validator
{
    public class ChoiceValidator : AbstractValidator<Choice>
    {
        public ChoiceValidator()
        {
            RuleFor(i => i.Id).NotNull().NotEmpty();
            RuleFor(i => i.Answer).NotNull().NotEmpty();
        }
    }
}
