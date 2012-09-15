using Associativy.GraphDiscovery;
using Associativy.Instances.Notions.Models;
using Associativy.Services;
using Orchard.Environment.Extensions;
using Piedone.HelpfulLibraries.DependencyInjection;
using Orchard.Environment;
using System;
using Orchard.Localization;

namespace Associativy.Instances.Notions
{
    [OrchardFeature("Associativy.Instances.Notions")]
    public class NotionsGraphProvider : IGraphProvider
    {
        private readonly Func<IPathServices> _pathServicesFactory;

        public Localizer T { get; set; }

        public NotionsGraphProvider(
            Work<ISqlConnectionManager<NotionToNotionConnectorRecord>> connectionManagerWork, 
            Work<IPathFinder> pathFinderWork)
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