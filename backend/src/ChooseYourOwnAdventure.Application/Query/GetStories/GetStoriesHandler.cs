using ChooseYourOwnAdventure.Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace ChooseYourOwnAdventure.Application.Query
{
    public class GetStoriesHandler : IRequestHandler<GetStoriesQuery, IEnumerable<SimpleStoryDetail>>
    {
        private readonly IStoryRepository _StoryRepository;
        private readonly IMapper _Mapper;

        public GetStoriesHandler(IStoryRepository storyRepository, IMapper mapper)
        {
            _StoryRepository = storyRepository;
            _Mapper = mapper;
        }

        public async Task<IEnumerable<SimpleStoryDetail>> Handle(GetStoriesQuery request, CancellationToken cancellationToken = default)
        {
            var stories = await _StoryRepository.GetStories();

            return _Mapper.Map<IEnumerable<SimpleStoryDetail>>(stories);
        }

    }
}
