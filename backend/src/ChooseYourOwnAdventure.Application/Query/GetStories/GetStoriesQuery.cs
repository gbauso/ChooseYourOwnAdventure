using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChooseYourOwnAdventure.Application.Query
{
    public class GetStoriesQuery : IRequest<IEnumerable<SimpleStoryDetail>>
    {
    }
}
