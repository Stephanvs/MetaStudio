using System.Collections.Generic;
using Hayman.Client.ReadModel.Blueprints.Graph;
using de.ahzf.blueprints;

namespace Hayman.Client.ReadModel.Blueprints.Meta
{
    public class MetaAssociation
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

        public MetaItem TargetMetaItem
        {
            get { return new MetaItem(_model, _edge.OutVertex.Id.ToString()); }
        }

        public MetaAssociation(Model model, string id)
        {
            _model = model;
            _edge = (model as IModelGraphAdapter).GetEdge(new EdgeId(id));
        }

		public override string ToString()
		{
			return string.Format("{0} -> {1}",
				SourceMetaItem.DefaultWord.Value,
				TargetMetaItem.DefaultWord.Value);
		}
    }
}