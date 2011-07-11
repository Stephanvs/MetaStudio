using System;
using de.ahzf.blueprints.GenericGraph;
using de.ahzf.blueprints;

namespace Hayman.Client.ReadModel.Blueprints.Graph
{
    public class HaymanEdge : IHaymanEdge
    {
        private readonly IHaymanVertex _outVertex;
        private readonly IHaymanVertex _inVertex;
        private readonly EdgeId _id;
        private readonly RevisionId _revisionId;

        public HaymanEdge(IHaymanVertex outVertex,
                          IHaymanVertex inVertex,
                          EdgeId id)
        {
            _outVertex = outVertex;
            _inVertex = inVertex;
            _id = id;
        }

        public HaymanEdgeData EdgeData { get; set; }

        public IGenericVertex<VertexId, RevisionId, HaymanVertexData, EdgeId, RevisionId, HaymanEdgeData, HyperEdgeId, RevisionId, HaymanEdgeData> InVertex
        {
            get { return _inVertex; }
        }

        public IGenericVertex<VertexId, RevisionId, HaymanVertexData, EdgeId, RevisionId, HaymanEdgeData, HyperEdgeId, RevisionId, HaymanEdgeData> OutVertex
        {
            get { return _outVertex; }
        }

        public HaymanEdgeData Data
        {
            get { return EdgeData; }
        }

        public EdgeId Id
        {
            get { return _id; }
        }

        public bool Equals(HaymanEdge other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._id, _id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (HaymanEdge)) return false;
            return Equals((HaymanEdge) obj);
        }

        public override int GetHashCode()
        {
            return (_id != null ? _id.GetHashCode() : 0);
        }

        public bool Equals(EdgeId other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(EdgeId other)
        {
            return Id.CompareTo(other);
        }

        public int CompareTo(object obj)
        {
            if (obj is HaymanEdge)
            {
                return CompareTo((obj as HaymanEdge).Id);
            }

            if (obj is EdgeId)
            {
                return CompareTo(obj as EdgeId);
            }

            return 0;
        }

        public RevisionId RevisionId
        {
            get { return _revisionId; }
        }

        public string Label
        {
            get { throw new NotImplementedException(); }
        }
    }
}
