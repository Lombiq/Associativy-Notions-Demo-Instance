using Associativy.Extensions;
using Associativy.Models;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;
using Associativy.Instances.Notions.Models;

namespace Associativy.Instances.Notions.Migrations
{
    [OrchardFeature("Associativy.Instances.Notions")]
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateNodeToNodeConnectorRecordTable<NotionToNotionConnectorRecord>();

            SchemaBuilder.CreateNodeToNodeConnectorRecordTable<HungarianNotionConnectorRecord>();

            ContentDefinitionManager.AlterTypeDefinition("Notion",
                cfg => cfg
                    .WithPart("CommonPart")
                    .WithPart("TitlePart")
                    .WithPart("AssociativyNodeManagementPart")
                    .WithLabel()
                    .Creatable()
            );


            return 1;
        }

        //public int UpdateFrom1()
        //{

        //    return 2;
        //}
    }
}