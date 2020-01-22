using AutoMapper;
using ChooseYourOwnAdventure.Application.Query.Model;
using ChooseYourOwnAdventure.Domain.Repositories;
using MediatR;
using ChooseYourOwnAdventure.CrossCutting.Exceptions;
using ChooseYourOwnAdventure.CrossCutting.Extensions;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace ChooseYourOwnAdventure.Application.Query
{
    public class GetStoryExecutionHandler : IRequestHandler<GetStoryExecutionQuery, ExecutionDetail>
    {
        private readonly IStepRepository _StepRepository;
        private readonly IStoryRepository _StoryRepository;
        private readonly IMapper _Mapper;

        public GetStoryExecutionHandler(IStepRepository stepRepository, IStoryRepository storyRepository, IMapper mapper)
        {
            _StepRepository = stepRepository;
            _StoryRepository = storyRepository;
            _Mapper = mapper;
        }

        public async Task<ExecutionDetail> Handle(GetStoryExecutionQuery request, CancellationToken cancellationToken = default)
        {
            var story = await _StoryRepository.GetStory(request.StoryId, true);
            story.Validate();

            var moves = await _StepRepository.GetAllMoves(request.SessionId);
            ValidateMoves(moves);

            var detail = new ExecutionDetail
            {
                Highlight = moves,
                Step = _Mapper.Map<ExecutionStepDetail>(story.RootStep)
            };

            return detail;
        }

        private void ValidateMoves(IEnumerable<Guid> movements)
        {
            if (movements.ListIsNullOrEmpty()) throw new ValidationException();
        }
    }
}
