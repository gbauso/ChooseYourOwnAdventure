using ChooseYourOwnAdventure.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourOwnAdventure.Domain.Repositories
{
    public interface IStepRepository
    {
        Task<Step> GetNextStep(Guid currentStepId, Guid choiceId);
        Task<bool> InsertMove(Guid sessionId, Guid currentStepId, Guid? choiceId = null);
        Task<IEnumerable<Guid>> GetAllMoves(Guid sessionId);
    }
}
