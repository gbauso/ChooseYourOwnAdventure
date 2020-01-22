using ChooseYourOwnAdventure.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourOwnAdventure.Domain.Repositories
{
    public interface IStoryRepository 
    {
        Task<IEnumerable<Story>> GetStories();
        Task<Story> GetStory(Guid id, bool complete = false);
        

    }
}
