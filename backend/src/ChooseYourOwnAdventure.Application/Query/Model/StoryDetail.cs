using System;
using System.Collections.Generic;
using System.Text;

namespace ChooseYourOwnAdventure.Application.Query
{
    public class StoryDetail 
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public StepDetail Root { get; set; }
    }
}
