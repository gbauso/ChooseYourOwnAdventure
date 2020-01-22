using ChooseYourOwnAdventure.Domain.Repositories;
using MediatR;
using AutoMapper;
using System.Threading.Tasks;
using System.Threading;

namespace ChooseYourOwnAdventure.Application.Query
{
    public class GetNextStepHandler : IRequestHandler<GetNextStepQuery, StepDetail>
    {
        private readonly IStepRepository _StoryRepository;
        private readonly IMapper _Mapper;

        public GetNextStepHandler(IStepRepository storyRepository, IMapper mapper)
        {
            _StoryRepository = storyRepository;
            _Mapper = mapper;
        }

        public async Task<StepDetail> Handle(GetNextStepQuery request, CancellationToken cancellationToken = default)
        {
            var step = await _StoryRepository.GetNextStep(request.StepId, request.ChoiceId);
            step.Validate();

            return _Mapper.Map<StepDetail>(step);
        }
    }
}
