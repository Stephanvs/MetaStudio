using System.Globalization;
using Hayman.Client.ReadModel.Blueprints.Graph;
using de.ahzf.blueprints;

namespace Hayman.Client.ReadModel.Blueprints.Meta
{
    public class Word
    {
        private readonly IHaymanVertex _vertex;

        public string Id
        {
            get { return _vertex.Id.ToString(); }
        }

        public CultureInfo Culture
        {
            get
            {
                return new CultureInfo(_vertex.Data.CultureName);
            }
        }

        public string Value
        {
            get { return _vertex.Data.Value; }
        }
        
        public Word(Model model, string id)
        {
            _vertex = (model as IModelGraphAdapter).GetVertex(new VertexId(id));
        }

        public bool Equals(Word other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._vertex, _vertex);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Word)) return false;
            return Equals((Word) obj);
        }

        public override int GetHashCode()
        {
            return (_vertex != null ? _vertex.GetHashCode() : 0);
        }
    }
}
