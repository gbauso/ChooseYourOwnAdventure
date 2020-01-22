using System;
using System.Collections.Generic;
using System.Text;

namespace ChooseYourOwnAdventure.Application.Query
{
    public class StepDetail
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public IEnumerable<ChoiceDetail> Choices { get; set; }
    }
}
