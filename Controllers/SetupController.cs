using System.Collections.Generic;
using System.Web.Mvc;
using Associativy.GraphDiscovery;
using Associativy.Models;
using Associativy.Services;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Core.Title.Models;
using Orchard.UI.Admin;

namespace Associativy.Instances.Notions.Controllers
{
    [Admin]
    public class SetupController : Controller
    {
        private readonly IAssociativyServices _associativyServices;
        private readonly IContentManager _contentManager;
        private readonly IOrchardServices _orchardServices;

        public SetupController(
            IAssociativyServices associativyServices,
            IOrchardServices orchardServices)
        {
            _associativyServices = associativyServices;
            _contentManager = orchardServices.ContentManager;
            _orchardServices = orchardServices;
        }

        public string Index()
        {
            var graph = _associativyServices.GraphManager.FindGraph(new GraphContext { Name = "AssociativyNotions" });

            new NotionGraphBuilder(_contentManager, graph).Build(true, false);

            return "Done";
        }

        public string Hungarian()
        {
            var graphContext = new GraphContext { Name = "AssociativyHungarianNotions" };
            var connectionManager = _associativyServices.GraphManager.FindGraph(graphContext).Services.ConnectionManager;

            var nodes = new Dictionary<string, IContent>();

            nodes["jég"] = NewNotion();
            nodes["fagyott"] = NewNotion();
            nodes["fagylalt"] = NewNotion();
            nodes["téli fagylalt"] = NewNotion();
            nodes["tél"] = NewNotion();
            nodes["víz"] = NewNotion();
            nodes["nyár"] = NewNotion();
            nodes["meleg"] = NewNotion();
            nodes["forró"] = NewNotion();
            nodes["tűz"] = NewNotion();
            nodes["tűzhely"] = NewNotion();
            nodes["gőz"] = NewNotion();
            nodes["oxigén"] = NewNotion();
            nodes["levegő"] = NewNotion();
            nodes["folyó"] = NewNotion();
            nodes["nitrogén"] = NewNotion();
            nodes["hidrogén"] = NewNotion();
            nodes["föld"] = NewNotion();
            nodes["út"] = NewNotion();
            nodes["autó"] = NewNotion();
            nodes["téligumi"] = NewNotion();
            nodes["fagyálló"] = NewNotion();
            nodes["sofőr"] = NewNotion();
            nodes["kerék"] = NewNotion();
            nodes["Audi"] = NewNotion();
            nodes["Suzuki"] = NewNotion();
            nodes["Maserati"] = NewNotion();
            nodes["BMW"] = NewNotion();
            nodes["Mercedes"] = NewNotion();
            nodes["benzin"] = NewNotion();
            nodes["Volkswagen"] = NewNotion();
            nodes["Skoda"] = NewNotion();
            nodes["Honda"] = NewNotion();
            nodes["márka"] = NewNotion(); ;
            nodes["német"] = NewNotion();
            nodes["kaiserlich und königlich"] = NewNotion();
            nodes["kuk"] = NewNotion();
            nodes["mozaikszó"] = NewNotion();
            nodes["OSZK"] = NewNotion();
            nodes["Országos Széchenyi Könyvtár"] = NewNotion();
            nodes["gumi"] = NewNotion();
            nodes["rágógumi"] = NewNotion();
            nodes["kaucsuk"] = NewNotion();
            nodes["Japán"] = NewNotion();
            nodes["motorbicikli"] = NewNotion();
            nodes["mission accomplished"] = NewNotion();
            nodes["feladat befejezve"] = NewNotion();
            nodes["Nap"] = NewNotion();
            nodes["sárga"] = NewNotion();
            nodes["lila"] = NewNotion();
            nodes["orgona"] = NewNotion();
            nodes["virág"] = NewNotion();
            nodes["szín"] = NewNotion();
            nodes["őselem"] = NewNotion();
            nodes["Prométheusz"] = NewNotion();

            foreach (var node in nodes)
            {
                node.Value.As<AssociativyNodeTitleLabelPart>().Label = node.Key;
                _contentManager.Create(node.Value);
            }

            connectionManager.Connect(nodes["mission accomplished"], nodes["feladat befejezve"]);
            connectionManager.Connect(nodes["Nap"], nodes["sárga"]);
            connectionManager.Connect(nodes["lila"], nodes["orgona"]);
            connectionManager.Connect(nodes["orgona"], nodes["virág"]);
            connectionManager.Connect(nodes["szín"], nodes["lila"]);
            connectionManager.Connect(nodes["szín"], nodes["sárga"]);
            connectionManager.Connect(nodes["német"], nodes["Volkswagen"]);
            connectionManager.Connect(nodes["német"], nodes["BMW"]);
            connectionManager.Connect(nodes["német"], nodes["Audi"]);
            connectionManager.Connect(nodes["német"], nodes["Mercedes"]);
            connectionManager.Connect(nodes["német"], nodes["kaiserlich und königlich"]);
            connectionManager.Connect(nodes["kaiserlich und königlich"], nodes["kuk"]);
            connectionManager.Connect(nodes["mozaikszó"], nodes["kuk"]);
            connectionManager.Connect(nodes["mozaikszó"], nodes["BMW"]);
            connectionManager.Connect(nodes["mozaikszó"], nodes["OSZK"]);
            connectionManager.Connect(nodes["Országos Széchenyi Könyvtár"], nodes["OSZK"]);
            connectionManager.Connect(nodes["gumi"], nodes["téligumi"]);
            connectionManager.Connect(nodes["gumi"], nodes["kerék"]);
            connectionManager.Connect(nodes["gumi"], nodes["rágógumi"]);
            connectionManager.Connect(nodes["gumi"], nodes["kaucsuk"]);
            connectionManager.Connect(nodes["Honda"], nodes["Japán"]);
            connectionManager.Connect(nodes["Honda"], nodes["motorbicikli"]);
            connectionManager.Connect(nodes["Audi"], nodes["márka"]);
            connectionManager.Connect(nodes["Suzuki"], nodes["márka"]);
            connectionManager.Connect(nodes["Maserati"], nodes["márka"]);
            connectionManager.Connect(nodes["BMW"], nodes["márka"]);
            connectionManager.Connect(nodes["Mercedes"], nodes["márka"]);
            connectionManager.Connect(nodes["Volkswagen"], nodes["márka"]);
            connectionManager.Connect(nodes["Skoda"], nodes["márka"]);
            connectionManager.Connect(nodes["Honda"], nodes["márka"]);
            connectionManager.Connect(nodes["téligumi"], nodes["autó"]);
            connectionManager.Connect(nodes["autó"], nodes["fagyálló"]);
            connectionManager.Connect(nodes["autó"], nodes["sofőr"]);
            connectionManager.Connect(nodes["autó"], nodes["kerék"]);
            connectionManager.Connect(nodes["autó"], nodes["Suzuki"]);
            connectionManager.Connect(nodes["autó"], nodes["Maserati"]);
            connectionManager.Connect(nodes["autó"], nodes["Audi"]);
            connectionManager.Connect(nodes["autó"], nodes["BMW"]);
            connectionManager.Connect(nodes["autó"], nodes["Mercedes"]);
            connectionManager.Connect(nodes["autó"], nodes["benzin"]);
            connectionManager.Connect(nodes["autó"], nodes["Volkswagen"]);
            connectionManager.Connect(nodes["autó"], nodes["Skoda"]);
            connectionManager.Connect(nodes["autó"], nodes["Honda"]);
            connectionManager.Connect(nodes["oxigén"], nodes["levegő"]);
            connectionManager.Connect(nodes["levegő"], nodes["őselem"]);
            connectionManager.Connect(nodes["víz"], nodes["őselem"]);
            connectionManager.Connect(nodes["folyó"], nodes["víz"]);
            connectionManager.Connect(nodes["nitrogén"], nodes["levegő"]);
            connectionManager.Connect(nodes["föld"], nodes["őselem"]);
            connectionManager.Connect(nodes["út"], nodes["föld"]);
            connectionManager.Connect(nodes["út"], nodes["autó"]);
            connectionManager.Connect(nodes["nyár"], nodes["meleg"]);
            connectionManager.Connect(nodes["nyár"], nodes["fagylalt"]);
            connectionManager.Connect(nodes["forró"], nodes["meleg"]);
            connectionManager.Connect(nodes["forró"], nodes["gőz"]);
            connectionManager.Connect(nodes["forró"], nodes["tűzhely"]);
            connectionManager.Connect(nodes["forró"], nodes["tűz"]);
            connectionManager.Connect(nodes["tűz"], nodes["tűzhely"]);
            connectionManager.Connect(nodes["tűz"], nodes["forró"]);
            connectionManager.Connect(nodes["tűz"], nodes["őselem"]);
            connectionManager.Connect(nodes["tűz"], nodes["Prométheusz"]);
            connectionManager.Connect(nodes["tűzhely"], nodes["gőz"]);
            connectionManager.Connect(nodes["jég"], nodes["tél"]);
            connectionManager.Connect(nodes["jég"], nodes["fagyott"]);
            connectionManager.Connect(nodes["fagyott"], nodes["fagylalt"]);
            connectionManager.Connect(nodes["fagylalt"], nodes["jég"]);
            connectionManager.Connect(nodes["téli fagylalt"], nodes["fagylalt"]);
            connectionManager.Connect(nodes["téli fagylalt"], nodes["meleg"]);
            connectionManager.Connect(nodes["tél"], nodes["téli fagylalt"]);
            connectionManager.Connect(nodes["tél"], nodes["nyár"]);
            connectionManager.Connect(nodes["tél"], nodes["téligumi"]);
            connectionManager.Connect(nodes["tél"], nodes["fagyálló"]);
            connectionManager.Connect(nodes["víz"], nodes["jég"]);
            connectionManager.Connect(nodes["víz"], nodes["hidrogén"]);
            connectionManager.Connect(nodes["víz"], nodes["gőz"]);
            connectionManager.Connect(nodes["víz"], nodes["oxigén"]);
            connectionManager.Connect(nodes["víz"], nodes["folyó"]);

            return "Done";
        }

        public string Neo4j()
        {
            var graph = _associativyServices.GraphManager.FindGraph(new GraphContext { Name = "Neo4jNotions" });

            new NotionGraphBuilder(_contentManager, graph).Build(true, true);

            return "Done";
        }

        private ContentItem NewNotion()
        {
            return _contentManager.New("Notion");
        }
    }
}