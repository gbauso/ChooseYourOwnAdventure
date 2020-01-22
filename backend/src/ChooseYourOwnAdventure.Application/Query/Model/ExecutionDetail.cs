using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ChooseYourOwnAdventure.Application.Query.Model
{
    public class ExecutionDetail
    {
        public IEnumerable<Guid> Highlight { get; set; }
        public ExecutionStepDetail Step { get; set; }

    }
}
