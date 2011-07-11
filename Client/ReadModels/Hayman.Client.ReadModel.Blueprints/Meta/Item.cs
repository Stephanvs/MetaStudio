using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Hayman.Client.ReadModel.Blueprints.Graph;
using de.ahzf.blueprints;

namespace Hayman.Client.ReadModel.Blueprints.Meta
{
    public class Item
    {
        private readonly Model _model;
        private readonly IHaymanVertex _vertex;

        public string Id
        {
            get { return _vertex.Id.ToString(); }
        }

        public IEnumerable<Word> Words
        {
            get
            {
                return _vertex.OutEdges
                                .Where(e => e.OutVertex.Data.Type.Equals(VertexType.Word))
                                .Select(e => new Word(_model, e.OutVertex.Id.ToString()));
            }
        }

        public Word DefaultWord
        {
            get { return Words.Where(w => w.Culture.Equals(CultureInfo.CurrentCulture)).SingleOrDefault(); }
        }

        public IEnumerable<Association> Associations
        {
            get
            {
                return _vertex.OutEdges
                    .Where(e => e.OutVertex.Data.Type.Equals(VertexType.Item))
                    .Select(e => new Association(_model, e.Id.ToString()));
            }
        }

        public Item(Model model, string id)
        {
            _model = model;
            _vertex = (model as IModelGraphAdapter).GetVertex(new VertexId(id));
        }

        public bool Equals(Item other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._vertex, _vertex);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Item)) return false;
            return Equals((Item) obj);
        }

        public override int GetHashCode()
        {
            return (_vertex != null ? _vertex.GetHashCode() : 0);
        }

		public override string ToString()
		{
			return String.Format("{0}", DefaultWord.Value);
		}
    }
}
