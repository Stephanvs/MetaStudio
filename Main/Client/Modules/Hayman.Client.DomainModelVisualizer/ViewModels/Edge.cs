using System;
using QuickGraph;
using System.Diagnostics;

namespace Hayman.Client.DomainModelVisualizerModule.ViewModels
{
    [DebuggerDisplay("{Source.Name} -> {Target.Name}")]
    public class Edge : Edge<Vertex>
    {
        public EdgeType Type { get; set; }

        public Edge(Vertex source, Vertex target, EdgeType type)
            : base(source, target)
        {
            Type = type;
        }
    }
}
