using AutoMapper;
using ChooseYourOwnAdventure.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChooseYourOwnAdventure.Application.Query
{
    public class GetStoryHandler : IRequestHandler<GetStoryQuery, StoryDetail>
    {
        private readonly IStoryRepository _StoryRepository;
        private readonly IMapper _Mapper;

        public GetStoryHandler(IStoryRepository storyRepository, IMapper mapper)
        {
            _StoryRepository = storyRepository;
            _Mapper = mapper;
        }

        public async Task<StoryDetail> Handle(GetStoryQuery request, CancellationToken cancellationToken = default)
        {
            var story = await _StoryRepository.GetStory(request.Id);
            story.Validate(false);

            return _Mapper.Map<StoryDetail>(story);
        }
    }
}
