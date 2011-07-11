using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Hayman.Client.ReadModel.Blueprints.Graph;
using de.ahzf.blueprints;

namespace Hayman.Client.ReadModel.Blueprints.Meta
{
    public class MetaItem
    {
        private readonly IHaymanVertex _vertex;
        private readonly Model _model;

        public string Id
        {
            get { return _vertex.Id.ToString(); }
        }

        public IEnumerable<Word> Words
        {
            get
            {
                return _vertex.OutEdges
                            .Where(e => e.OutVertex.Data.Type == VertexType.Word)
                            .Select(e => new Word(_model, e.OutVertex.Id.ToString()));
            }
        }

    	public IEnumerable<Item> Items
    	{
    		get
    		{
    			return _vertex.OutEdges
    				.Where(e => e.OutVertex.Data.Type == VertexType.Item)
    				.Select(e => new Item(_model, e.OutVertex.Id.ToString()));
    		}
    	}

        public Word DefaultWord
        {
            get { return Words.Where(w => w.Culture.Equals(CultureInfo.CurrentCulture)).SingleOrDefault(); }
        }

        public IEnumerable<MetaAssociation> MetaAssociations
        {
            get
            {
                return _vertex.OutEdges
                    .Where(e => e.OutVertex.Data.Type == VertexType.MetaItem)
                    .Select(e => new MetaAssociation(_model, e.Id.ToString()));
            }
        }

        public MetaItem(Model model, string id)
        {
            _model = model;
            _vertex = (model as IModelGraphAdapter).GetVertex(new VertexId(id));
        }

        public bool Equals(MetaItem other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._vertex, _vertex);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (MetaItem)) return false;
            return Equals((MetaItem) obj);
        }

        public override int GetHashCode()
        {
            return (_vertex != null ? _vertex.GetHashCode() : 0);
        }

		public override string ToString()
		{
			return DefaultWord.Value;
		}
    }
}
