using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Associativy.GraphDiscovery;
using Associativy.Services;
using Orchard.Localization;
using Associativy.Neo4j.Services;
using Orchard.Environment;
using Orchard.Environment.Extensions;

namespace Associativy.Instances.Notions
{
    [OrchardFeature("Associativy.Instances.Notions.Neo4j")]
    public class Neo4jNotionsGraphProvider : IGraphProvider
    {
        private readonly Func<IPathServices> _pathServicesFactory;

        public Localizer T { get; set; }

        public const string Name = "AssociativyWikipedia";


        public Neo4jNotionsGraphProvider(
            Work<INeo4jConnectionManager> connectionManagerWork,
            Work<INeo4jPathFinder> pathFinderWork,
            Work<IStandardPathFinder> standardPathFinderWork)
        {
            _pathServicesFactory = () =>
            {
                var connectionManager = connectionManagerWork.Value;
                connectionManager.RootUri = new Uri("http://localhost:7474/db/data/");
                return new PathServices(connectionManager, standardPathFinderWork.Value/*pathFinderWork.Value*/);
            };

            T = NullLocalizer.Instance;
        }


        public void Describe(DescribeContext describeContext)
        {
            describeContext.DescribeGraph(
                "Neo4jNotions",
                T("Neo4j Notions"),
                new[] { "Notion" },
                _pathServicesFactory);
        }
    }
}