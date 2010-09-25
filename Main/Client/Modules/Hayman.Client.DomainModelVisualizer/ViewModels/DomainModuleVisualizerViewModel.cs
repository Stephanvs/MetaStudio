using System;
using Hayman.Client.DomainModelVisualizerModule.DomainModelServiceReference;
using Hayman.Client.DomainModelVisualizerModule.ViewModels;
using Hayman.Client.Presentation.Windows.ViewModels;

namespace Hayman.Client.DomainModelVisualizerModule.ViewModels
{
    public class DomainModuleVisualizerViewModel : WorkspaceWindowViewModel
	{
		public Graph Graph { get; set; }

		public DomainModuleVisualizerViewModel() : base("Domain Modeler")
		{
			using (var service = new DomainModelServiceClient())
			{
				service.Open();
				MetaModelDto metaModel = service.GetMetaModel("");
				Graph = BuildGraph(metaModel);
				service.Close();
			}
		}

        private static Graph BuildGraph(MetaModelDto metaModel)
        {
            var graph = new Graph();
            Vertex rootMetaitemVertex = new Vertex(metaModel.RootItem.Name);
            graph.AddVertex(rootMetaitemVertex);
            BuildGraphStep(graph, metaModel.RootItem, rootMetaitemVertex);
            return graph;
        }

        private static void BuildGraphStep(Graph graph, MetaitemDto metaitem, Vertex parent)
        {
            foreach (MetaAssociationDto association in metaitem.Associations)
            {
                var vertex = new Vertex(association.Target.Name);
                graph.AddVertex(vertex);

                var edge = new Edge(parent, vertex, EdgeType.Reference);
                graph.AddEdge(edge);

                BuildGraphStep(graph, association.Target, vertex);
            }
        }
	}
}
