using Associativy.Extensions;
using Associativy.Instances.Notions.Models;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;

namespace Associativy.Instances.Notions.Migrations
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateNodeToNodeConnectorRecordTable<NotionToNotionConnectorRecord>();

            SchemaBuilder.CreateNodeToNodeConnectorRecordTable<HungarianNotionConnectorRecord>();

            ContentDefinitionManager.AlterTypeDefinition("Notion",
                cfg => cfg
                    .WithPart("CommonPart")
                    .WithTitleLabel()
                    .WithPart("AssociativyNodeManagementPart")
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