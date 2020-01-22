using System;
using System.Collections.Generic;

namespace ChooseYourOwnAdventure.Application.Query.Model
{
    public class ExecutionStepDetail
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ExecutionChoiceDetail> Children { get; set; }
    }
}
