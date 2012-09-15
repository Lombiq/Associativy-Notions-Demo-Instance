using Associativy.GraphDiscovery;
using Associativy.Instances.Notions.Models;
using Associativy.Services;
using Orchard.Environment.Extensions;
using Piedone.HelpfulLibraries.DependencyInjection;
using System;
using Orchard.Localization;
using Orchard.Environment;

namespace Associativy.Instances.Notions
{
    [OrchardFeature("Associativy.Instances.Notions")]
    public class HungarianNotionsGraphProvider : IGraphProvider
    {
        private readonly Func<IPathServices> _pathServicesFactory;

        public Localizer T { get; set; }

        public HungarianNotionsGraphProvider(
            Work<ISqlConnectionManager<HungarianNotionConnectorRecord>> connectionManagerWork,
            Work<IPathFinder> pathFinderWork)
        {
            _pathServicesFactory = () => new PathServices(connectionManagerWork.Value, pathFinderWork.Value);

            T = NullLocalizer.Instance;
        }

        public void Describe(DescribeContext describeContext)
        {
            describeContext.DescribeGraph(
                "AssociativyHungarianNotions",
                T("Associativy Hungarian Notions"),
                new[] { "Notion" },
                _pathServicesFactory);
        }
    }
}