
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChooseYourOwnAdventure.CrossCutting.Exceptions;
using ChooseYourOwnAdventure.CrossCutting.Extensions;
using ChooseYourOwnAdventure.Domain.Model;
using ChooseYourOwnAdventure.Domain.Repositories;
using Neo4jClient;
using Newtonsoft.Json;

namespace ChooseYourOwnAdventure.Infrastructure.Repositories
{
    public class StoryRepository : IStoryRepository
    {
        private readonly IFactory<GraphClient> _Factory;

        public StoryRepository(IFactory<GraphClient> factory)
        {
            _Factory = factory;
        }

        

        public async Task<IEnumerable<Story>> GetStories()
        {
            using (var session = _Factory.GetInstance())
            {
                await session.ConnectAsync();
                var query = session.Cypher
                    .Match("(story:Story)")
                    .With("{id: story.storyRef, title: story.title} as value")
                    .Return<string>("collect(value)");

                var storiesJson = query.Results.FirstOrDefault();
                storiesJson.ValidateJSON();

                var story = JsonConvert.DeserializeObject<IEnumerable<Story>>(storiesJson);

                return story;
            }
        }

        public async Task<Story> GetStory(Guid id, bool complete = true)
        {
            using (var session = _Factory.GetInstance())
            {
                await session.ConnectAsync();

                var endMatch = complete ? "(choice: Choice)-[*]->(leaf)" : "(choice: Choice)";

                var query = session.Cypher
                    .Match($"p=(:Story {{storyRef:'{id.ToString()}'}})-[:STARTS_WITH]->(step:Step)" +
                           $"-[:HAS*]->{endMatch}")
                    .With("collect(p) as paths")
                    .Call("apoc.convert.toTree(paths) yield value")
                    .Return<string>("value");

                if (query.Results.ListIsNullOrEmpty()) throw new NotFoundException();

                var storyJson = query.Results.FirstOrDefault();
                storyJson.ValidateJSON();

                var story = JsonConvert.DeserializeObject<Story>(storyJson.NormalizeNeo4jJson());

                return story;
            }

        }


    }
}
