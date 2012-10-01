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
    public class NotionsGraphProvider : IGraphProvider
    {
        private readonly Func<IPathServices> _pathServicesFactory;

        public Localizer T { get; set; }

        // Notice the lazy-loading of path services
        public NotionsGraphProvider(
            Work<ISqlConnectionManager<NotionToNotionConnectorRecord>> connectionManagerWork, 
            Work<IStandardPathFinder> pathFinderWork)
        {
            _pathServicesFactory = () => new PathServices(connectionManagerWork.Value, pathFinderWork.Value);

            T = NullLocalizer.Instance;
        }

        public void Describe(DescribeContext describeContext)
        {
            describeContext.DescribeGraph(
                "AssociativyNotions",
                T("Associativy Notions"),
                new[] { "Notion" },
                _pathServicesFactory);
        }
    }
}