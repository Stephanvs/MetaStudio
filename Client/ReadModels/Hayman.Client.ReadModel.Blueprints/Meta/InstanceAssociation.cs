using Hayman.Client.ReadModel.Blueprints.Graph;
using de.ahzf.blueprints;

namespace Hayman.Client.ReadModel.Blueprints.Meta
{
    public class InstanceAssociation
    {
        private readonly IHaymanEdge _edge;
        private readonly Model _model;

        public string Id
        {
            get { return _edge.Id.ToString(); }
        }

        public MetaItem SourceMetaItem
        {
            get { return new MetaItem(_model, _edge.InVertex.Id.ToString()); }
        }

        public Item TargetItem
        {
            get { return new Item(_model, _edge.OutVertex.Id.ToString()); }
        }

        public InstanceAssociation(Model model, string id)
        {
            _model = model;
            _edge = (model as IModelGraphAdapter).GetEdge(new EdgeId(id));
        }
    }
}
