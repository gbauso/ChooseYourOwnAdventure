using ChooseYourOwnAdventure.CrossCutting.Exceptions;
using ChooseYourOwnAdventure.Domain.Validator;
using System;
using System.Linq;
using Json = Newtonsoft.Json;

namespace ChooseYourOwnAdventure.Domain.Model
{
    public class Choice : IDomain
    {
        [Json.JsonConstructor]
        public Choice(string id, string answer, Step[] to)
        {
            Id = Guid.Parse(id);
            Answer = answer;
            To = to?.ElementAtOrDefault(0);
        }

        public Choice(Guid id, string label, Step targetStep = default)
        {
            Id = id;
            Answer = label;
            To = targetStep;
        }

        public Choice(string label, Step targetStep = default)
        {
            Id = Guid.NewGuid();
            Answer = label;
            To = targetStep;
        }

        public Guid Id { get; private set; }
        public string Answer { get; private set; }
        public Step To { get; private set; }

        public void Validate(params bool[] properties)
        {
            var validator = new ChoiceValidator();
            var isValid = validator.Validate(this).IsValid;

            if (!isValid) throw new ValidationException();
        }

    }
}
