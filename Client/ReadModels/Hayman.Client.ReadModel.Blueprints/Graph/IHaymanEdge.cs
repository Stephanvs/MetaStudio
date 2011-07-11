using de.ahzf.blueprints;
using de.ahzf.blueprints.GenericGraph;

namespace Hayman.Client.ReadModel.Blueprints.Graph
{
    public interface IHaymanEdge : IGenericEdge<VertexId, RevisionId, HaymanVertexData,
                                    EdgeId, RevisionId, HaymanEdgeData,
                                    HyperEdgeId, RevisionId, HaymanEdgeData>
    {
        HaymanEdgeData EdgeData { get; set; }
    }
}
