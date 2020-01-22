using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChooseYourOwnAdventure.Application.Query
{
    public class GetNextStepQuery : IRequest<StepDetail>
    {
        public GetNextStepQuery()
        {

        }
        public GetNextStepQuery(Guid stepId, Guid choiceId)
        {
            StepId = stepId;
            ChoiceId = choiceId;
        }

        public Guid StepId { get; set; }
        public Guid ChoiceId { get; set; }
    }
}
