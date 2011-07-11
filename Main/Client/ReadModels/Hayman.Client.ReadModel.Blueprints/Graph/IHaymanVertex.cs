using de.ahzf.blueprints;
using de.ahzf.blueprints.GenericGraph;

namespace Hayman.Client.ReadModel.Blueprints.Graph
{
    public interface IHaymanVertex : IGenericVertex<VertexId, RevisionId, HaymanVertexData,
                                      EdgeId, RevisionId, HaymanEdgeData,
                                      HyperEdgeId, RevisionId, HaymanEdgeData>
    {
        HaymanVertexData VertexData { get; set; }
    }
}
