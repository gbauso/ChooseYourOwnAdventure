using MediatR;
using System;

namespace ChooseYourOwnAdventure.Application.Query
{
    public class GetStoryQuery : IRequest<StoryDetail>
    {
        public GetStoryQuery()
        {

        }
        public GetStoryQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
