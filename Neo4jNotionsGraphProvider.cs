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
        private readonly Func<IGraphDescriptor, IGraphServices> _graphServicesFactory;

        public Localizer T { get; set; }

        public const string Name = "AssociativyWikipedia";


        public Neo4jNotionsGraphProvider(
            Func<IGraphDescriptor, IStandardMind> mindFactory,
            Func<IGraphDescriptor, Uri, INeo4jConnectionManager> connectionManagerFactory,
            Func<IGraphDescriptor, IStandardPathFinder> pathFinderFactory,
            Func<IGraphDescriptor, IStandardNodeManager> nodeManagerFactory,
            Func<IGraphDescriptor, IStandardGraphStatisticsService> graphStatisticsServiceFactory)
        {
            _graphServicesFactory = (graphDescriptor) =>
            {
                return new GraphServices(
                    mindFactory(graphDescriptor),
                    connectionManagerFactory(graphDescriptor, new Uri("http://localhost:7474/db/data/")),
                    pathFinderFactory(graphDescriptor),
                    nodeManagerFactory(graphDescriptor),
                    graphStatisticsServiceFactory(graphDescriptor));
            };

            T = NullLocalizer.Instance;
        }


        public void Describe(DescribeContext describeContext)
        {
            describeContext.DescribeGraph(
                "Neo4jNotions",
                T("Neo4j Notions"),
                new[] { "Notion" },
                _graphServicesFactory);
        }
    }
}