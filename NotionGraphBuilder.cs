using System.Collections.Generic;
using Associativy.GraphDiscovery;
using Associativy.Services;
using Orchard.ContentManagement;
using Orchard.Core.Title.Models;
using Associativy.Models;
using System.Linq;

namespace Associativy.Instances.Notions
{
    public class NotionGraphBuilder
    {
        private readonly IContentManager _contentManager;
        private readonly IGraphDescriptor _graphDescriptor;
        private readonly IConnectionManager _connectionManager;

        public Dictionary<string, IContent> Nodes { get; set; }


        public NotionGraphBuilder(
            IContentManager contentManager,
            IGraphDescriptor graphDescriptor)
        {
            _contentManager = contentManager;
            _graphDescriptor = graphDescriptor;
            _connectionManager = graphDescriptor.Services.ConnectionManager;
        }


        public void Build(bool setTitle, bool justConnect)
        {
            Nodes = new Dictionary<string, IContent>();

            if (!justConnect)
            {
                Nodes["medicine"] = NewNotion();
                Nodes["cyanide"] = NewNotion();
                Nodes["cyan"] = NewNotion();
                Nodes["red"] = NewNotion();
                Nodes["green"] = NewNotion();
                Nodes["blue"] = NewNotion();
                Nodes["magenta"] = NewNotion();
                Nodes["yellow"] = NewNotion();
                Nodes["black"] = NewNotion();
                Nodes["light"] = NewNotion();
                Nodes["light speed"] = NewNotion();
                Nodes["light year"] = NewNotion();
                Nodes["colour"] = NewNotion();
                Nodes["grass"] = NewNotion();
                Nodes["plant"] = NewNotion();
                Nodes["tree"] = NewNotion();
                Nodes["flower"] = NewNotion();
                Nodes["power plant"] = NewNotion();
                Nodes["electricity"] = NewNotion();
                Nodes["nuclear power plant"] = NewNotion();
                Nodes["hydroelectric power plant"] = NewNotion();
                Nodes["solar power"] = NewNotion();
                Nodes["water"] = NewNotion();
                Nodes["sun"] = NewNotion();
                Nodes["USA"] = NewNotion();
                Nodes["American"] = NewNotion();
                Nodes["Ernest Hemingway"] = NewNotion();
                Nodes["writer"] = NewNotion();
                Nodes["Jókai Mór"] = NewNotion();
                Nodes["Karl May"] = NewNotion();

                foreach (var node in Nodes)
                {
                    if (setTitle) node.Value.As<AssociativyNodeTitleLabelPart>().Label = node.Key;
                    _contentManager.Create(node.Value);
                } 
            }
            else
            {
                Nodes["medicine"] = FetchNode("medicine");
                Nodes["cyanide"] = FetchNode("cyanide");
                Nodes["cyan"] = FetchNode("cyan");
                Nodes["red"] = FetchNode("red");
                Nodes["green"] = FetchNode("green");
                Nodes["blue"] = FetchNode("blue");
                Nodes["magenta"] = FetchNode("magenta");
                Nodes["yellow"] = FetchNode("yellow");
                Nodes["black"] = FetchNode("black");
                Nodes["light"] = FetchNode("light");
                Nodes["light speed"] = FetchNode("light speed");
                Nodes["light year"] = FetchNode("light year");
                Nodes["colour"] = FetchNode("colour");
                Nodes["grass"] = FetchNode("grass");
                Nodes["plant"] = FetchNode("plant");
                Nodes["tree"] = FetchNode("tree");
                Nodes["flower"] = FetchNode("flower");
                Nodes["power plant"] = FetchNode("power plant");
                Nodes["electricity"] = FetchNode("electricity");
                Nodes["nuclear power plant"] = FetchNode("nuclear power plant");
                Nodes["hydroelectric power plant"] = FetchNode("hydroelectric power plant");
                Nodes["solar power"] = FetchNode("solar power");
                Nodes["water"] = FetchNode("water");
                Nodes["sun"] = FetchNode("sun");
                Nodes["USA"] = FetchNode("USA");
                Nodes["American"] = FetchNode("American");
                Nodes["Ernest Hemingway"] = FetchNode("Ernest Hemingway");
                Nodes["writer"] = FetchNode("writer");
                Nodes["Jókai Mór"] = FetchNode("Jókai Mór");
                Nodes["Karl May"] = FetchNode("Karl May");
            }

            _connectionManager.Connect(Nodes["medicine"], Nodes["cyanide"]);
            _connectionManager.Connect(Nodes["cyanide"], Nodes["cyan"]);
            _connectionManager.Connect(Nodes["cyan"], Nodes["colour"]);
            _connectionManager.Connect(Nodes["red"], Nodes["colour"]);
            _connectionManager.Connect(Nodes["green"], Nodes["colour"]);
            _connectionManager.Connect(Nodes["blue"], Nodes["colour"]);
            _connectionManager.Connect(Nodes["magenta"], Nodes["colour"]);
            _connectionManager.Connect(Nodes["yellow"], Nodes["colour"]);
            _connectionManager.Connect(Nodes["black"], Nodes["colour"]);
            _connectionManager.Connect(Nodes["light"], Nodes["colour"]);
            _connectionManager.Connect(Nodes["light"], Nodes["light speed"]);
            _connectionManager.Connect(Nodes["light"], Nodes["light year"]);
            _connectionManager.Connect(Nodes["green"], Nodes["grass"]);
            _connectionManager.Connect(Nodes["grass"], Nodes["plant"]);
            _connectionManager.Connect(Nodes["plant"], Nodes["tree"]);
            _connectionManager.Connect(Nodes["plant"], Nodes["flower"]);
            _connectionManager.Connect(Nodes["plant"], Nodes["power plant"]);
            _connectionManager.Connect(Nodes["electricity"], Nodes["power plant"]);
            _connectionManager.Connect(Nodes["nuclear power plant"], Nodes["power plant"]);
            _connectionManager.Connect(Nodes["hydroelectric power plant"], Nodes["power plant"]);
            _connectionManager.Connect(Nodes["nuclear power plant"], Nodes["electricity"]);
            _connectionManager.Connect(Nodes["hydroelectric power plant"], Nodes["electricity"]);
            _connectionManager.Connect(Nodes["hydroelectric power plant"], Nodes["water"]);
            _connectionManager.Connect(Nodes["solar power"], Nodes["electricity"]);
            _connectionManager.Connect(Nodes["solar power"], Nodes["green"]);
            _connectionManager.Connect(Nodes["water"], Nodes["blue"]);
            _connectionManager.Connect(Nodes["sun"], Nodes["light"]);
            _connectionManager.Connect(Nodes["sun"], Nodes["yellow"]);
            _connectionManager.Connect(Nodes["sun"], Nodes["solar power"]);
            _connectionManager.Connect(Nodes["USA"], Nodes["American"]);
            _connectionManager.Connect(Nodes["American"], Nodes["Ernest Hemingway"]);
            _connectionManager.Connect(Nodes["Ernest Hemingway"], Nodes["writer"]);
            _connectionManager.Connect(Nodes["Jókai Mór"], Nodes["writer"]);
            _connectionManager.Connect(Nodes["Karl May"], Nodes["writer"]);
        }

        private ContentItem NewNotion()
        {
            return _contentManager.New("Notion");
        }

        private ContentItem FetchNode(string label)
        {
            return _contentManager
                        .Query<AssociativyNodeLabelPart, AssociativyNodeLabelPartRecord>()
                        .Where(part => part.Label == label).List().First().ContentItem;
        }
    }
}