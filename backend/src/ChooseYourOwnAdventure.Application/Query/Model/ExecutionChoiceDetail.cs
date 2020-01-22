using System;
using System.Collections.Generic;
using System.Text;

namespace ChooseYourOwnAdventure.Application.Query.Model
{
    public class ExecutionChoiceDetail
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ExecutionStepDetail> Children { get; set; }
    }
}
