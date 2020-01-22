using Microsoft.Extensions.Options;
using Neo4j.Driver;
using Neo4jClient;
using System;

namespace ChooseYourOwnAdventure.Infrastructure
{
    public class ConnectionFactory : IFactory<GraphClient>
    {
        private readonly IOptions<Neo4jConfiguration> _DatabaseConfiguration;

        public ConnectionFactory(IOptions<Neo4jConfiguration> options)
        {
            _DatabaseConfiguration = options;
        }

        public virtual GraphClient GetInstance()
        {
            var configuration = _DatabaseConfiguration.Value;
            var driver = new GraphClient(new Uri(configuration.Uri), configuration.Username, configuration.Password);

            return driver;
        }
    }
}
