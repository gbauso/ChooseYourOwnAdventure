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
    public class StepRepository : IStepRepository
    {
        private readonly IFactory<GraphClient> _Factory;

        public StepRepository(IFactory<GraphClient> factory)
        {
            _Factory = factory;
        }


        public async Task<Step> GetNextStep(Guid currentStepId, Guid choiceId)
        {
            using (var session = _Factory.GetInstance())
            {
                await session.ConnectAsync();
                var query = session.Cypher
                    .Match($"(step:Step {{stepRef: '{currentStepId.ToString()}'}})" +
                            $"-[:HAS]->(:Choice {{decisionRef: '{choiceId.ToString()}'}})" +
                            $"-[:RESULTS_IN]->(next:Step)")
                    .OptionalMatch("p=(next)-[:HAS]->(choice:Choice)")
                    .With("CASE WHEN choice IS NULL THEN [] ELSE COLLECT({id: choice.decisionRef, answer: choice.answer}) END AS list, next")
                    .With("{id: next.stepRef, first: next.first, label: next.label, choices: list} as result")
                    .Return<string>("result");

                if (query.Results.ListIsNullOrEmpty()) throw new NotFoundException();

                var stepJson = query.Results.FirstOrDefault();
                stepJson.ValidateJSON();

                var step = JsonConvert.DeserializeObject<Step>(stepJson);

                return step;
            }
        }

        public async Task<IEnumerable<Guid>> GetAllMoves(Guid sessionId)
        {
            using (var session = _Factory.GetInstance())
            {
                await session.ConnectAsync();
                var query = session.Cypher
                    .Match($"(:Session {{sessionRef: '{sessionId.ToString()}'}})-[:REACHES]->(leaf)")
                    .With("CASE WHEN leaf.decisionRef IS NOT NULL THEN leaf.decisionRef ELSE leaf.stepRef END as id")
                    .Return<string>("collect(id)");

                if (query.Results.ListIsNullOrEmpty()) throw new NotFoundException();

                var movesJson = query.Results.FirstOrDefault();
                movesJson.ValidateJSON();

                var moves = JsonConvert.DeserializeObject<IEnumerable<Guid>>(movesJson);

                return moves;
            }
        }

        public async Task<bool> InsertMove(Guid sessionId, Guid currentStepId, Guid? choiceId = null)
        {
            using (var session = _Factory.GetInstance())
            {
                await session.ConnectAsync();
                var command = session.Cypher
                    .Create($"(session:Session {{sessionRef: '{sessionId.ToString()}'}})")
                    .With("session")
                    .Match($"(step:Step {{stepRef: '{currentStepId.ToString()}'}})")
                    .With("session, step")
                    .Create("(session)-[:REACHES]->(step)");

                if (choiceId.HasValue)
                {
                    command = command
                        .With("session")
                        .Match($"(choice:Choice {{decisionRef: '{choiceId.ToString()}'}})")
                        .With("session, choice")
                        .Create($"(session)-[:REACHES]->(choice)");
                }

                try
                {
                    command.ExecuteWithoutResults();
                }
                catch
                {
                    throw new DatabaseCommandException();
                }

                return true;
            }
        }
    }
}
