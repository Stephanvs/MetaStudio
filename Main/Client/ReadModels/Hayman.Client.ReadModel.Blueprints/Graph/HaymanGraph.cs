using System.Collections.Generic;
using System.Linq;
using de.ahzf.blueprints;
using System;

namespace Hayman.Client.ReadModel.Blueprints.Graph
{
	public class HaymanGraph : IHaymanGraph
	{
		private readonly IDictionary<VertexId, IHaymanVertex> _vertices = new Dictionary<VertexId, IHaymanVertex>();
		private readonly IDictionary<EdgeId, IHaymanEdge> _edges = new Dictionary<EdgeId, IHaymanEdge>();

		public string Name { get; private set; }

		public HaymanGraph(string name)
		{
			Name = name;
		}

		/// <summary>
		/// Remove all the edges and vertices from the graph.
		/// </summary>
		public void Clear()
		{
			_vertices.Clear();
			_edges.Clear();
		}

		/// <summary>
		/// A shutdown function is required to properly close the graph.
		/// This is important for implementations that utilize disk-based serializations.
		/// </summary>
		public void Shutdown()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Create a new vertex, add it to the graph, and return the newly created vertex.
        /// The provided object identifier is a recommendation for the identifier to use.
        /// It is not required that the implementation use this identifier.
        /// If the object identifier is already being used by the graph to reference a vertex,
        /// then that reference vertex is returned and no vertex is created.
        /// If the identifier is a vertex (perhaps from another graph),
        /// then the vertex is duplicated for this graph. Thus, a vertex can not be an identifier.
		/// </summary>
		/// <param name="vertexId">The recommended object identifier.</param><param name="vertexInitializer">A delegate to initialize the new vertex.</param>
		/// <returns>
		/// The newly created vertex or the vertex already referenced by the provided identifier.
		/// </returns>
		public IHaymanVertex AddVertex(VertexId vertexId, Action<HaymanVertexData> vertexInitializer)
		{
			var data = new HaymanVertexData();
			vertexInitializer(data);
			return AddVertex(new HaymanVertex(vertexId, null) { VertexData = data });
		}

		public IHaymanVertex AddVertex(IHaymanVertex vertex)
		{
			_vertices.Add(vertex.Id, vertex);
			return vertex;
		}

		/// <summary>
		/// Return the vertex referenced by the given vertex identifier.
		/// If no vertex is referenced by that identifier, then return null.
		/// </summary>
		/// <param name="vertexId">The identifier of the vertex.</param>
		/// <returns>
		/// The vertex referenced by the provided identifier or null when no such edge exists.
		/// </returns>
		public IHaymanVertex GetVertex(VertexId vertexId)
		{
			IHaymanVertex vertex;
			_vertices.TryGetValue(vertexId, out vertex);
			return vertex;
		}

		/// <summary>
		/// Return a collection of vertices referenced by the given array of vertex identifiers.
		/// </summary>
		/// <param name="vertexIds">An array of vertex identifiers.</param>
		public IEnumerable<IHaymanVertex> GetVertices(params VertexId[] vertexIds)
		{
			return vertexIds.Select(id => _vertices[id]);
		}

		/// <summary>
		/// Get an enumeration of all vertices in the graph.
		/// An additional vertex filter may be applied for filtering.
		/// </summary>
		/// <param name="vertexFilter">A delegate for vertex filtering.</param>
		public IEnumerable<IHaymanVertex> GetVertices(Func<IHaymanVertex, bool> vertexFilter)
		{
			return _vertices
					.Where(v => vertexFilter(v.Value))
					.Select(v => v.Value);
		}

		/// <summary>
		/// Remove the provided vertex from the graph.
		/// Upon removing the vertex, all the edges by which the vertex is connected will be removed as well.
		/// </summary>
		/// <param name="vertex">The vertex to be removed from the graph</param>
		public void RemoveVertex(IHaymanVertex vertex)
		{
			_vertices.Remove(vertex.Id);
		}

		/// <summary>
		/// Add an edge to the graph. The added edges requires a recommended identifier, a tail vertex, an head vertex, and a label.
		/// Like adding a vertex, the provided object identifier is can be ignored by the implementation.
		/// </summary>
		/// <param name="outVertex">The vertex on the tail of the edge.</param>
		/// <param name="inVertex">The vertex on the head of the edge.</param>
		/// <param name="id">The recommended object identifier.</param>
		/// <param name="label">The label associated with the edge.</param>
		/// <param name="edgeInitializer">A delegate to initialize the new edge.</param>
		/// <returns>
		/// The newly created edge
		/// </returns>
		public IHaymanEdge AddEdge(IHaymanVertex outVertex, IHaymanVertex inVertex, EdgeId id, string label, Action<HaymanEdgeData> edgeInitializer)
		{
            var data = new HaymanEdgeData();

            if (edgeInitializer != null)
            {
                
                edgeInitializer(data);
            }

		    var edge = new HaymanEdge(outVertex, inVertex, id) { EdgeData = data };
            outVertex.AddInEdge(edge);
            inVertex.AddOutEdge(edge);
			_edges.Add(id, edge);
			return edge;
		}

		/// <summary>
		/// Return the edge referenced by the given edge identifier.
		///  If no edge is referenced by that identifier, then return null.
		/// </summary>
		/// <param name="edgeId">The identifier of the edge.</param>
		/// <returns>
		/// The edge referenced by the provided identifier or null when no such edge exists.
		/// </returns>
		public IHaymanEdge GetEdge(EdgeId edgeId)
		{
			IHaymanEdge edge;
			_edges.TryGetValue(edgeId, out edge);
			return edge;
		}

		/// <summary>
		/// Get an enumeration of all edges in the graph.
		/// An additional edge filter may be applied for filtering.
		/// </summary>
		/// <param name="edgeIds">An array of edge identifiers.</param>
		public IEnumerable<IHaymanEdge> GetEdges(params EdgeId[] edgeIds)
		{
			return edgeIds.Select(id => _edges[id]);
		}

		/// <summary>
		/// Get an enumeration of all edges in the graph.
		/// An additional edge filter may be applied for filtering.
		/// </summary>
		/// <param name="edgeFilter">A delegate for edge filtering.</param>
		public IEnumerable<IHaymanEdge> GetEdges(Func<IHaymanEdge, bool> edgeFilter)
		{
			return _edges
					.Where(v => edgeFilter(v.Value))
					.Select(v => v.Value);
		}

		/// <summary>
		/// Remove the provided edge from the graph.
		/// </summary>
		/// <param name="edge">The edge to be removed from the graph</param>
		public void RemoveEdge(IHaymanEdge edge)
		{
			_edges.Remove(edge.Id);
		}

		/// <summary>
		/// Get an enumeration of all vertices in the graph.
		/// </summary>
		public IEnumerable<IHaymanVertex> Vertices
		{
			get { return _vertices.Values; }
		}

		/// <summary>
		/// Get an enumeration of all edges in the graph.
		/// </summary>
		public IEnumerable<IHaymanEdge> Edges
		{
			get { return _edges.Values; }
		}
	}
}