using ChooseYourOwnAdventure.Application.Query.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChooseYourOwnAdventure.Application.Query
{
    public class GetStoryExecutionQuery : IRequest<ExecutionDetail>
    {
        public GetStoryExecutionQuery()
        {

        }
        public GetStoryExecutionQuery(Guid storyId, Guid sessionId)
        {
            StoryId = storyId;
            SessionId = sessionId;
        }

        public Guid StoryId { get; set; }
        public Guid SessionId { get; set; }
    }
}
