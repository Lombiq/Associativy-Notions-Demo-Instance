﻿using System;
using Associativy.GraphDiscovery;
using Associativy.Neo4j.Services;
using Associativy.Services;
using Orchard.Environment.Extensions;
using Orchard.Localization;

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
            Func<IGraphDescriptor, Uri, INeo4jPathFinder> pathFinderFactory,
            Func<IGraphDescriptor, IStandardNodeManager> nodeManagerFactory)
        {
            _graphServicesFactory = (graphDescriptor) =>
            {
                var neo4jUri = new Uri("http://localhost:7474/db/data/");

                return new GraphServices(
                    mindFactory(graphDescriptor),
                    connectionManagerFactory(graphDescriptor, neo4jUri),
                    pathFinderFactory(graphDescriptor, neo4jUri),
                    nodeManagerFactory(graphDescriptor));
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