using System;
using System.Collections.Generic;
using System.Text;

namespace ChooseYourOwnAdventure.Application.Query
{
    public class ChoiceDetail
    {
        public Guid Id { get; set; }
        public string Answer { get; set; }
        public StepDetail Next { get; set; }
    }
}
