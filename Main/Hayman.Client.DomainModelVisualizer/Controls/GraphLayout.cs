using System;
using GraphSharp.Controls;
using GraphSharp.Algorithms.Layout.Simple.Tree;
using Hayman.Client.DomainModelVisualizerModule.ViewModels;

namespace Hayman.Client.DomainModelVisualizerModule.Controls
{
    public class GraphLayout : GraphLayout<Vertex, Edge, Graph> 
    {
        public GraphLayout()
        {
            LayoutParameters = new SimpleTreeLayoutParameters { LayerGap = 50, VertexGap = 50 };
        }
    }
}
