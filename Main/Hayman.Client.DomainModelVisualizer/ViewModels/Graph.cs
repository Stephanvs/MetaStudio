using System;
using QuickGraph;

namespace Hayman.Client.DomainModelVisualizerModule.ViewModels
{
    public class Graph : BidirectionalGraph<Vertex, Edge>
    {
        public Graph()
        {
        }
        public Graph(bool allowParallelEdges)
            : base(allowParallelEdges)
        {
        }
        public Graph(bool allowParallelEdges, int vertexCapacity)
            : base(allowParallelEdges, vertexCapacity)
        {
        }
    }
}
