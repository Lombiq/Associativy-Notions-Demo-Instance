using Associativy.Models;
using Associativy.Services;
using Orchard.Environment.Extensions;
using Piedone.HelpfulLibraries.DependencyInjection;
using Associativy.GraphDiscovery;
using Associativy.Instances.Notions.Models;

namespace Associativy.Instances.Notions
{
    [OrchardFeature("Associativy.Instances.Notions")]
    public class HungarianNotionsGraphProvider : GraphProviderBase<IDatabaseConnectionManager<HungarianNotionConnectorRecord>>
    {
        public HungarianNotionsGraphProvider(IResolve<IDatabaseConnectionManager<HungarianNotionConnectorRecord>> connectionManagerResolver)
            : base(connectionManagerResolver)
        {
        }

        public override void Describe(DescribeContext describeContext)
        {
            describeContext.DescribeGraph(
                "AssociativyHungarianNotions",
                T("Associativy Hungarian Notions"),
                new[] { "Notion" },
                ConnectionManager);
        }
    }
}