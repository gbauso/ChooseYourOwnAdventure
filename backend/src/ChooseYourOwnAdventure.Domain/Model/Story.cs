using ChooseYourOwnAdventure.CrossCutting.Exceptions;
using ChooseYourOwnAdventure.CrossCutting.Extensions;
using ChooseYourOwnAdventure.Domain.Validator;
using System;
using System.Linq;
using Json = Newtonsoft.Json;

namespace ChooseYourOwnAdventure.Domain.Model
{
    public class Story : IDomain
    {
        [Json.JsonConstructor]
        public Story(Guid id, string title, Step[] rootStep)
        {
            Id = id;
            Title = title;
            RootStep = rootStep?.ElementAtOrDefault(0);
        }


        public Story(Guid id, string title, Step rootStep = default)
        {
            Id = id;
            Title = title;
            RootStep = rootStep;
        }

        public Story(string title, Step rootStep = default)
        {
            Id = Guid.NewGuid();
            Title = title;
            RootStep = rootStep;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }

        public Step RootStep { get; private set; }

        public void Validate(params bool[] properties)
        {
            var validateAllStory = properties.ListIsNullOrEmpty() ? true : properties.ElementAt(0);

            var validator = new StoryValidator(validateAllStory);
            var isValid = validator.Validate(this).IsValid;

            if (!isValid) throw new ValidationException();
        }
    }
}
