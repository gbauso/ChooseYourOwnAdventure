using AutoMapper;
using ChooseYourOwnAdventure.Application.Query;
using ChooseYourOwnAdventure.Application.Query.Model;
using ChooseYourOwnAdventure.Domain.Model;

namespace ChooseYourOwnAdventure.Application.Mapping
{
    public class StoryProfile : Profile
    {
        public StoryProfile()
        {
            CreateMap<Story, SimpleStoryDetail>();

            CreateMap<Story, StoryDetail>()
                .ForMember(i => i.Root, j => j.MapFrom(m => m.RootStep));

            CreateMap<Step, StepDetail>()
                .ForMember(i => i.Question, j => j.MapFrom(m => m.Label));

            CreateMap<Choice, ChoiceDetail>()
                .ForMember(i => i.Next, j => j.MapFrom(m => m.To));

            CreateMap<Step, ExecutionStepDetail>()
                .ForMember(i => i.Name, j => j.MapFrom(m => m.Label))
                .ForMember(i => i.Children, j => j.MapFrom(m => m.Choices));

            CreateMap<Choice, ExecutionChoiceDetail>()
                .ForMember(i => i.Name, j => j.MapFrom(m => m.Answer))
                .ForMember(i => i.Children, j => j.MapFrom(m => new[] { m.To }));

        }
    }
}
