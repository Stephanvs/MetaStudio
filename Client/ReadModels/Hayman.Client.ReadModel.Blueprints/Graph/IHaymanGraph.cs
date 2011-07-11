using de.ahzf.blueprints;
using de.ahzf.blueprints.GenericGraph;

namespace Hayman.Client.ReadModel.Blueprints.Graph
{
    interface IHaymanGraph : IGenericGraph< // Vertex definition
                        VertexId, RevisionId,
                        HaymanVertexData,
                        IHaymanVertex,

                        // Edge definition
                        EdgeId, RevisionId,
                        HaymanEdgeData,
                        IHaymanEdge,

                        // Hyperedge definition
                        HyperEdgeId, RevisionId,
                        HaymanEdgeData,
                        IGenericHyperEdge<VertexId, RevisionId, HaymanVertexData,
                                 EdgeId, RevisionId, HaymanEdgeData,
                                 HyperEdgeId, RevisionId, HaymanEdgeData>>
    {
    }
}
