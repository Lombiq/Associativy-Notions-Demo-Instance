using System.Collections.Generic;
using Associativy.GraphDiscovery;
using Associativy.Services;
using Orchard.ContentManagement;
using Orchard.Core.Title.Models;

namespace Associativy.Instances.Notions
{
    public class NotionGraphBuilder
    {
        private readonly IContentManager _contentManager;
        private readonly IGraphContext _graphContext;
        private readonly IConnectionManager _connectionManager;

        public Dictionary<string, IContent> Nodes { get; set; }

        public NotionGraphBuilder(
            IContentManager contentManager, 
            IGraphContext graphContext,
            IConnectionManager connectionManager)
        {
            _contentManager = contentManager;
            _graphContext = graphContext;
            _connectionManager = connectionManager;
        }

        public void Build(bool setTitle)
        {
            Nodes = new Dictionary<string, IContent>();

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
                if (setTitle) node.Value.As<TitlePart>().Title = node.Key;
                _contentManager.Create(node.Value);
            }

            _connectionManager.Connect(_graphContext, Nodes["medicine"], Nodes["cyanide"]);
            _connectionManager.Connect(_graphContext, Nodes["cyanide"], Nodes["cyan"]);
            _connectionManager.Connect(_graphContext, Nodes["cyan"], Nodes["colour"]);
            _connectionManager.Connect(_graphContext, Nodes["red"], Nodes["colour"]);
            _connectionManager.Connect(_graphContext, Nodes["green"], Nodes["colour"]);
            _connectionManager.Connect(_graphContext, Nodes["blue"], Nodes["colour"]);
            _connectionManager.Connect(_graphContext, Nodes["magenta"], Nodes["colour"]);
            _connectionManager.Connect(_graphContext, Nodes["yellow"], Nodes["colour"]);
            _connectionManager.Connect(_graphContext, Nodes["black"], Nodes["colour"]);
            _connectionManager.Connect(_graphContext, Nodes["light"], Nodes["colour"]);
            _connectionManager.Connect(_graphContext, Nodes["light"], Nodes["light speed"]);
            _connectionManager.Connect(_graphContext, Nodes["light"], Nodes["light year"]);
            _connectionManager.Connect(_graphContext, Nodes["green"], Nodes["grass"]);
            _connectionManager.Connect(_graphContext, Nodes["grass"], Nodes["plant"]);
            _connectionManager.Connect(_graphContext, Nodes["plant"], Nodes["tree"]);
            _connectionManager.Connect(_graphContext, Nodes["plant"], Nodes["flower"]);
            _connectionManager.Connect(_graphContext, Nodes["plant"], Nodes["power plant"]);
            _connectionManager.Connect(_graphContext, Nodes["electricity"], Nodes["power plant"]);
            _connectionManager.Connect(_graphContext, Nodes["nuclear power plant"], Nodes["power plant"]);
            _connectionManager.Connect(_graphContext, Nodes["hydroelectric power plant"], Nodes["power plant"]);
            _connectionManager.Connect(_graphContext, Nodes["nuclear power plant"], Nodes["electricity"]);
            _connectionManager.Connect(_graphContext, Nodes["hydroelectric power plant"], Nodes["electricity"]);
            _connectionManager.Connect(_graphContext, Nodes["hydroelectric power plant"], Nodes["water"]);
            _connectionManager.Connect(_graphContext, Nodes["solar power"], Nodes["electricity"]);
            _connectionManager.Connect(_graphContext, Nodes["solar power"], Nodes["green"]);
            _connectionManager.Connect(_graphContext, Nodes["water"], Nodes["blue"]);
            _connectionManager.Connect(_graphContext, Nodes["sun"], Nodes["light"]);
            _connectionManager.Connect(_graphContext, Nodes["sun"], Nodes["yellow"]);
            _connectionManager.Connect(_graphContext, Nodes["sun"], Nodes["solar power"]);
            _connectionManager.Connect(_graphContext, Nodes["USA"], Nodes["American"]);
            _connectionManager.Connect(_graphContext, Nodes["American"], Nodes["Ernest Hemingway"]);
            _connectionManager.Connect(_graphContext, Nodes["Ernest Hemingway"], Nodes["writer"]);
            _connectionManager.Connect(_graphContext, Nodes["Jókai Mór"], Nodes["writer"]);
            _connectionManager.Connect(_graphContext, Nodes["Karl May"], Nodes["writer"]);
        }

        private ContentItem NewNotion()
        {
            return _contentManager.New("Notion");
        }
    }
}