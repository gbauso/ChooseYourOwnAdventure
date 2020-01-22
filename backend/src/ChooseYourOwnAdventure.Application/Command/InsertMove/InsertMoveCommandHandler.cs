using AutoMapper;
using ChooseYourOwnAdventure.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChooseYourOwnAdventure.Application.Command
{
    public class InsertMoveCommandHandler : IRequestHandler<InsertMoveCommand, bool>
    {
        private readonly IStepRepository _StoryRepository;

        public InsertMoveCommandHandler(IStepRepository storyRepository)
        {
            _StoryRepository = storyRepository;
        }

        public async Task<bool> Handle(InsertMoveCommand request, CancellationToken cancellationToken = default)
        {
            var command = await _StoryRepository.InsertMove(request.SessionId,
                                                      request.CurrentStepId,
                                                      request.ChoiceId);

            return command;
        }

    }
}
