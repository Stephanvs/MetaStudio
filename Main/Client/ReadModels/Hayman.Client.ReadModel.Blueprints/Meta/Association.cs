using Hayman.Client.ReadModel.Blueprints.Graph;
using de.ahzf.blueprints;

namespace Hayman.Client.ReadModel.Blueprints.Meta
{
    public class Association
    {
        private readonly IHaymanEdge _edge;
        private readonly Model _model;

        public string Id
        {
            get { return _edge.Id.ToString(); }
        }

        public Item SourceItem
        {
            get { return new Item(_model, _edge.InVertex.Id.ToString()); }
        }

        public Item TargetItem
        {
            get { return new Item(_model, _edge.OutVertex.Id.ToString()); }
        }

        public Association(Model model, string id)
        {
            _model = model;
            _edge = (model as IModelGraphAdapter).GetEdge(new EdgeId(id));
        }

        public bool Equals(Association other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._edge, _edge);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Association)) return false;
            return Equals((Association) obj);
        }

        public override int GetHashCode()
        {
            return (_edge != null ? _edge.GetHashCode() : 0);
        }

		public override string ToString()
		{
			return string.Format("{0} -> {1}", SourceItem.DefaultWord.Value, TargetItem.DefaultWord.Value);
		}
    }
}
