using System.Collections.Generic;
using de.ahzf.blueprints.GenericGraph;
using de.ahzf.blueprints;
using System.Linq;

namespace Hayman.Client.ReadModel.Blueprints.Graph
{
    public class HaymanVertex : IHaymanVertex
    {
        private readonly VertexId _id;
        private readonly RevisionId _revisionId;
        private readonly IDictionary<EdgeId, IGenericEdge<VertexId, RevisionId, HaymanVertexData, EdgeId, RevisionId, HaymanEdgeData, HyperEdgeId, RevisionId, HaymanEdgeData>> _outEdges; 
        private readonly IDictionary<EdgeId, IGenericEdge<VertexId, RevisionId, HaymanVertexData, EdgeId, RevisionId, HaymanEdgeData, HyperEdgeId, RevisionId, HaymanEdgeData>> _inEdges;

        public HaymanVertex(VertexId id, RevisionId revisionId)
        {
            _id = id;
            _revisionId = revisionId;
            _outEdges = new Dictionary<EdgeId, IGenericEdge<VertexId, RevisionId, HaymanVertexData, EdgeId, RevisionId, HaymanEdgeData, HyperEdgeId, RevisionId, HaymanEdgeData>>();
            _inEdges = new Dictionary<EdgeId, IGenericEdge<VertexId, RevisionId, HaymanVertexData, EdgeId, RevisionId, HaymanEdgeData, HyperEdgeId, RevisionId, HaymanEdgeData>>();
        }

        public HaymanVertexData VertexData { get; set; }

        public void AddInEdge(IGenericEdge<VertexId, RevisionId, HaymanVertexData, EdgeId, RevisionId, HaymanEdgeData, HyperEdgeId, RevisionId, HaymanEdgeData> edge)
        {
            _inEdges.Add(edge.Id, edge);
        }

        public void AddOutEdge(IGenericEdge<VertexId, RevisionId, HaymanVertexData, EdgeId, RevisionId, HaymanEdgeData, HyperEdgeId, RevisionId, HaymanEdgeData> edge)
        {
            _outEdges.Add(edge.Id, edge);
        }

        public IEnumerable<IGenericEdge<VertexId, RevisionId, HaymanVertexData, EdgeId, RevisionId, HaymanEdgeData, HyperEdgeId, RevisionId, HaymanEdgeData>> GetInEdges(string label)
        {
            return _inEdges
                    .Where(e => e.Value.Label == label)
                    .Select(e => e.Value);
        }

        public IEnumerable<IGenericEdge<VertexId, RevisionId, HaymanVertexData, EdgeId, RevisionId, HaymanEdgeData, HyperEdgeId, RevisionId, HaymanEdgeData>> GetOutEdges(string label)
        {
            return _outEdges
                    .Where(e => e.Value.Label == label)
                    .Select(e => e.Value);
        }

        public IEnumerable<IGenericEdge<VertexId, RevisionId, HaymanVertexData, EdgeId, RevisionId, HaymanEdgeData, HyperEdgeId, RevisionId, HaymanEdgeData>> InEdges
        {
            get { return _inEdges.Values; }
        }

        public IEnumerable<IGenericEdge<VertexId, RevisionId, HaymanVertexData, EdgeId, RevisionId, HaymanEdgeData, HyperEdgeId, RevisionId, HaymanEdgeData>> OutEdges
        {
            get { return _outEdges.Values; }
        }

        public void RemoveInEdge(IGenericEdge<VertexId, RevisionId, HaymanVertexData, EdgeId, RevisionId, HaymanEdgeData, HyperEdgeId, RevisionId, HaymanEdgeData> edge)
        {
            _inEdges.Remove(edge.Id);
        }

        public void RemoveOutEdge(IGenericEdge<VertexId, RevisionId, HaymanVertexData, EdgeId, RevisionId, HaymanEdgeData, HyperEdgeId, RevisionId, HaymanEdgeData> edge)
        {
            _outEdges.Remove(edge.Id);
        }

        public HaymanVertexData Data
        {
            get { return VertexData; }
        }

        public VertexId Id
        {
            get { return _id; }
        }

        public bool Equals(HaymanVertex other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._id, _id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (HaymanVertex)) return false;
            return Equals((HaymanVertex) obj);
        }

        public override int GetHashCode()
        {
            return (_id != null ? _id.GetHashCode() : 0);
        }

        public bool Equals(VertexId other)
        {
            return Id.Equals(other);
        }

        public int CompareTo(VertexId other)
        {
            return Id.CompareTo(other);
        }

        public int CompareTo(object obj)
        {
            if (obj is HaymanVertex)
            {
                return CompareTo((obj as HaymanVertex).Id);
            }

            if (obj is VertexId)
            {
                return CompareTo((obj as VertexId));
            }

            return 0;
        }

        public RevisionId RevisionId
        {
            get { return _revisionId; }
        }
    }
}
