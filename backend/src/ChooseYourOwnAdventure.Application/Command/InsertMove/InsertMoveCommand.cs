using ChooseYourOwnAdventure.CrossCutting.Exceptions;
using ChooseYourOwnAdventure.CrossCutting.Extensions;
using MediatR;
using System;

namespace ChooseYourOwnAdventure.Application.Command
{
    public class InsertMoveCommand : IRequest<bool>
    {
        public InsertMoveCommand()
        {

        }
        public InsertMoveCommand(Guid sessionId, Guid currentStepId, Guid? choiceId)
        {
            SessionId = sessionId;
            CurrentStepId = currentStepId;
            ChoiceId = choiceId;
        }

        public Guid SessionId { get; set; }
        public Guid CurrentStepId { get; set; }
        public Guid? ChoiceId { get; set; }

        public void Validate()
        {
            var isValid = SessionId.IsNull() || CurrentStepId.IsNull();

            if (!isValid) throw new ValidationException();
        }

    }
}
