using ChooseYourOwnAdventure.CrossCutting.Exceptions;
using ChooseYourOwnAdventure.Domain.Validator;
using System;
using System.Collections.Generic;
using Json = Newtonsoft.Json;

namespace ChooseYourOwnAdventure.Domain.Model
{
    public class Step : IDomain
    {
        [Json.JsonConstructor]
        public Step(Guid id, string label, bool first, ICollection<Choice> choices = default)
        {
            Id = id;
            Label = label;
            First = first;
            Choices = choices;
        }

        public Step(string label, bool first, ICollection<Choice> choices = default)
        {
            Id = Guid.NewGuid();
            Label = label;
            First = first;
            Choices = choices;
        }

        public Guid Id { get; private set; }
        public string Label { get; private set; }
        public bool First { get; private set; }

        public ICollection<Choice> Choices { get; private set; }

        public void Validate(params bool[] properties)
        {
            var validator = new StepValidator();
            var isValid = validator.Validate(this).IsValid;

            if (!isValid) throw new ValidationException();
        }
    }
}
