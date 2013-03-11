using System;
using Associativy.GraphDiscovery;
using Associativy.Instances.Notions.Models;
using Associativy.Services;
using Orchard.Environment;
using Orchard.Environment.Extensions;
using Orchard.Localization;

namespace Associativy.Instances.Notions
{
    [OrchardFeature("Associativy.Instances.Notions")]
    public class HungarianNotionsGraphProvider : IGraphProvider
    {
        private readonly IGraphServicesFactory _graphServicesFactory;

        public Localizer T { get; set; }


        // Notice the lazy-loading of path services
        public HungarianNotionsGraphProvider(IGraphServicesFactory<IStandardMind, ISqlConnectionManager<HungarianNotionConnectorRecord>, IStandardPathFinder, IStandardNodeManager, ISqlConnectionManager<HungarianNotionConnectorRecord>> graphServicesFactory)
        {
            _graphServicesFactory = graphServicesFactory;

            T = NullLocalizer.Instance;
        }


        public void Describe(DescribeContext describeContext)
        {
            describeContext.DescribeGraph(
                "AssociativyHungarianNotions",
                T("Associativy Hungarian Notions"),
                new[] { "Notion" },
                _graphServicesFactory.Factory);
        }
    }
}