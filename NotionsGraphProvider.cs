using Associativy.GraphDiscovery;
using Associativy.Instances.Notions.Models;
using Associativy.Services;
using Orchard.Localization;

namespace Associativy.Instances.Notions
{
    public class NotionsGraphProvider : IGraphProvider
    {
        private readonly IGraphServicesFactory _graphServicesFactory;

        public Localizer T { get; set; }


        // Notice the lazy-loading of path services
        public NotionsGraphProvider(IGraphServicesFactory<IStandardMind, ISqlConnectionManager<NotionToNotionConnectorRecord>, IStandardPathFinder, IStandardNodeManager> graphServicesFactory)
        {
            _graphServicesFactory = graphServicesFactory;

            T = NullLocalizer.Instance;
        }


        public void Describe(DescribeContext describeContext)
        {
            describeContext.DescribeGraph(
                "Notions",
                T("Notions"),
                new[] { "Notion" },
                _graphServicesFactory.Factory);
        }
    }
}