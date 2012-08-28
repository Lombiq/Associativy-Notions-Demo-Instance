using Associativy.GraphDiscovery;
using Associativy.Instances.Notions.Models;
using Associativy.Services;
using Orchard.Environment.Extensions;
using Piedone.HelpfulLibraries.DependencyInjection;

namespace Associativy.Instances.Notions
{
    [OrchardFeature("Associativy.Instances.Notions")]
    public class NotionsGraphProvider : GraphProviderBase<IDatabaseConnectionManager<NotionToNotionConnectorRecord>>
    {
        public NotionsGraphProvider(IResolve<IDatabaseConnectionManager<NotionToNotionConnectorRecord>> connectionManagerResolver) 
            : base(connectionManagerResolver)
        {
        }

        public override void Describe(DescribeContext describeContext)
        {
            describeContext.DescribeGraph(
                "AssociativyNotions",
                T("Associativy Notions"),
                new[] { "Notion" },
                ConnectionManager);
        }
    }
}