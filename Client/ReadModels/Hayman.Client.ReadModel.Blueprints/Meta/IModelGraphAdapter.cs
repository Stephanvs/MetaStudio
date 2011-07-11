using Hayman.Client.ReadModel.Blueprints.Graph;
using de.ahzf.blueprints;

namespace Hayman.Client.ReadModel.Blueprints.Meta
{
    interface IModelGraphAdapter
    {
        IHaymanVertex GetVertex(VertexId id);
        IHaymanEdge GetEdge(EdgeId id);
    }
}
