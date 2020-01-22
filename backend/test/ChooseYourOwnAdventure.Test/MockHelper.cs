using AutoMapper;
using Bogus;
using ChooseYourOwnAdventure.Application.Mapping;
using ChooseYourOwnAdventure.Domain.Model;
using ChooseYourOwnAdventure.Domain.Repositories;
using ChooseYourOwnAdventure.Infrastructure;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChooseYourOwnAdventure.Test
{
    public class MockHelper
    {
        #region Mock/Fake Data
        public static Story GetMockStory(bool isValid = true)
        {
            var jsonFileSuffix = isValid ? "valid_story" : "invalid_story";

            var mockFile = $"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}mock_{jsonFileSuffix}.json";

            var json = File.ReadAllText(mockFile);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<Story>(json);
        }

        public static Step GetFakeStep(bool firstStep = false)
        {
            var fakeChoice = new Faker<Choice>()
                .CustomInstantiator(f => new Choice(f.Lorem.Word()));

            var fakeStep = new Faker<Step>()
                .CustomInstantiator(f => new Step(f.Lorem.Word(), firstStep, fakeChoice.Generate(2)));

            return fakeStep.Generate();
        }

        public static Story GetFakeStory()
        {
            var fakeStory = new Faker<Story>()
                .CustomInstantiator(f => new Story(f.Lorem.Sentence(2), GetFakeStep(true)));

            return fakeStory.Generate();
        }

        public static IEnumerable<Story> GetFakeStories(int length = 3)
        {
            var fakeStory = new Faker<Story>()
                .CustomInstantiator(f => new Story(f.Lorem.Sentence(2)));

            return fakeStory.Generate(length);
        }

        public static IEnumerable<Guid> GetMoves(int length = 3)
        {
            return Enumerable.Range(0, length).Select(i => Guid.NewGuid());
        }
        #endregion

        #region Repositories 


        public static IStoryRepository GetStoryRepository()
        {
            var mock = new Mock<IStoryRepository>();
            var storiesResult = Task.FromResult(GetFakeStories());
            var completeStoryResult = Task.FromResult(GetMockStory());
            var partialStoryResult = Task.FromResult(GetFakeStory());

            mock.Setup(i => i.GetStories()).Returns(storiesResult);
            mock.Setup(i => i.GetStory(It.IsAny<Guid>(), true)).Returns(completeStoryResult);
            mock.Setup(i => i.GetStory(It.IsAny<Guid>(), false)).Returns(partialStoryResult);

            return mock.Object;
        }

        public static IStepRepository GetStepRepository()
        {
            var mock = new Mock<IStepRepository>();
            var movesResult = Task.FromResult(GetMoves());
            var nextStepResult = Task.FromResult(GetFakeStep());
            var partialStoryResult = Task.FromResult(GetFakeStory());

            mock.Setup(i => i.GetAllMoves(It.IsAny<Guid>())).Returns(movesResult);
            mock.Setup(i => i.GetNextStep(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns(nextStepResult);
            mock.Setup(i => i.InsertMove(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<Guid>())).Returns(Task.FromResult(true));

            return mock.Object;
        }

        public static IMapper GetMapper()
        {
            var profiles = new Profile[] { new StoryProfile() };
            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(profiles));
            var mapper = new Mapper(configuration);

            return mapper;
        }

        #endregion

    }
}
