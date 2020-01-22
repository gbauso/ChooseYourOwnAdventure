using System;
using System.Collections.Generic;
using System.Text;

namespace ChooseYourOwnAdventure.Infrastructure
{
    public class Neo4jConfiguration
    {
        public string Uri { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
    }
}
