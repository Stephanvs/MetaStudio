using System;
using System.Collections.Generic;
using System.Globalization;
using Hayman.Client.ReadModel.Blueprints.Graph;
using de.ahzf.blueprints;
using System.Linq;

namespace Hayman.Client.ReadModel.Blueprints.Meta
{
    public class Model : IModelGraphAdapter
    {
        private readonly HaymanGraph _graph;

        public string Name
        {
            get { return _graph.Name; }
        }

        public Model(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(name, "Name cannot be null or empty.");
            }

            _graph = new HaymanGraph(name);
        }

        #region MetaItem

        public MetaItem AddMetaItem(string word)
        {
            return AddMetaItem(word, CultureInfo.CurrentCulture.Name);
        }

        public MetaItem AddMetaItem(string word, string cultureName)
        {
            if (string.IsNullOrEmpty(word))
            {
                throw new ArgumentNullException("word", "Word cannot be null or empty.");
            }

            if (_graph.Vertices.Any(v => v.Data.Type.Equals(VertexType.Word) && v.Data.Value.Equals(word)))
            {
                throw new InvalidOperationException("Cannot add the same MetaItem twice");
            }

            var metaItemVertex = new HaymanVertex(VertexId.NewVertexId, null) { VertexData = new HaymanVertexData { Type = VertexType.MetaItem } };
            var wordVertex = new HaymanVertex(VertexId.NewVertexId, null) { VertexData = new HaymanVertexData { Type = VertexType.Word, Value = word, CultureName = cultureName } };

            _graph.AddVertex(metaItemVertex);
            _graph.AddVertex(wordVertex);
            _graph.AddEdge(wordVertex, metaItemVertex, EdgeId.NewEdgeId, "", null);

            return new MetaItem(this, metaItemVertex.Id.ToString());
        }

        public void RemoveMetaItem(string id)
        {
            var vertex = _graph.GetVertex(new VertexId(id));
            _graph.RemoveVertex(vertex);
        }

        public MetaItem GetMetaItem(string id)
        {
            return new MetaItem(this, id);
        }

        public IEnumerable<MetaItem> MetaItems
        {
            get
            {
                return _graph.Vertices
                        .Where(v => v.VertexData.Type.Equals(VertexType.MetaItem))
                        .Select(v => new MetaItem(this, v.Id.ToString()));
            }
        }

        #endregion

        #region Item

        public Item AddItem(string word)
        {
            return AddItem(word, CultureInfo.CurrentCulture.Name);
        }

        public Item AddItem(string word, string cultureName)
        {
            if (string.IsNullOrEmpty(word))
            {
                throw new ArgumentNullException("word", "Word cannot be null or empty.");
            }

            if (_graph.Vertices.Any(v => v.Data.Type.Equals(VertexType.Word) && v.Data.Value.Equals(word)))
            {
                throw new InvalidOperationException("Cannot add the same Item twice");
            }

            var itemVertex = new HaymanVertex(VertexId.NewVertexId, null) { VertexData = new HaymanVertexData { Type = VertexType.Item } };
            var wordVertex = new HaymanVertex(VertexId.NewVertexId, null) { VertexData = new HaymanVertexData { Type = VertexType.Word, Value = word, CultureName = cultureName } };

            _graph.AddVertex(itemVertex);
            _graph.AddVertex(wordVertex);
            _graph.AddEdge(wordVertex, itemVertex, EdgeId.NewEdgeId, "", null);

            return new Item(this, itemVertex.Id.ToString());
        }

        public void RemoveItem(string id)
        {
            var vertex = _graph.GetVertex(new VertexId(id));
            _graph.RemoveVertex(vertex);
        }

        public Item GetItem(string id)
        {
            return new Item(this, id);
        }

        public IEnumerable<Item> Items
        {
            get
            {
                return _graph.Vertices
                        .Where(v => v.VertexData.Type == VertexType.Item)
                        .Select(v => new Item(this, v.Id.ToString()));
            }
        } 

        #endregion

        #region Word

        public Word AddWord(string word)
        {
            return AddWord(word);
        }

        public Word AddWord(string word, string cultureName)
        {
            var wordVertex = new HaymanVertex(VertexId.NewVertexId, null) { VertexData = new HaymanVertexData { Type = VertexType.Word, CultureName = cultureName } };

            _graph.AddVertex(wordVertex);

            return new Word(this, wordVertex.Id.ToString());
        }

        public void RemoveWord(string id)
        {
            var vertex = _graph.GetVertex(new VertexId(id));
            _graph.RemoveVertex(vertex);
        }

        public Word GetWord(string id)
        {
            return new Word(this, id);
        }

        public IEnumerable<Word> Words
        {
            get
            {
                return _graph.Vertices
                        .Where(v => v.VertexData.Type.Equals(VertexType.Word))
                        .Select(v => new Word(this, v.Id.ToString()));
            }
        }

        #endregion

        #region MetaAssociation

        public MetaAssociation AddMetaAssocation(string metaItemSourceId, string metaItemTargetId)
        {
            var metaItemInVertex = _graph.Vertices
                                        .Where(v => v.Id.ToString().Equals(metaItemSourceId))
                                        .SingleOrDefault();

            var metaItemOutVertex = _graph.Vertices
                                        .Where(v => v.Id.ToString().Equals(metaItemTargetId))
                                        .SingleOrDefault();

            var metaAssociationEdge = _graph.AddEdge(metaItemOutVertex, metaItemInVertex, EdgeId.NewEdgeId, "", null);
            return new MetaAssociation(this, metaAssociationEdge.Id.ToString());
        }

        public void RemoveMetaAssocation(string id)
        {
            var edge = _graph.GetEdge(new EdgeId(id));
            _graph.RemoveEdge(edge);
        }

        public MetaAssociation GetMetaAssocation(string id)
        {
            return new MetaAssociation(this, id);
        }

        public IEnumerable<MetaAssociation> MetaAssociations
        {
            get
            {
                return _graph.Edges
                        .Where(v => v.InVertex.Data.Type.Equals(VertexType.MetaItem) &&
                                    v.OutVertex.Data.Type.Equals(VertexType.MetaItem))
                        .Select(v => new MetaAssociation(this, v.Id.ToString()));
            }
        }

        #endregion

        #region Association

        public Association AddAssociation(string itemSourceId, string itemTargetId)
        {
            if (_graph.Edges.Any(e => e.InVertex.Id.ToString().Equals(itemSourceId) && e.OutVertex.Id.ToString().Equals(itemTargetId)))
            {
                throw new InvalidOperationException("Cannot add the same Association to a Model twice.");
            }

            var itemInVertex = _graph.Vertices
                                        .Where(v => v.Id.ToString().Equals(itemSourceId))
                                        .SingleOrDefault();

            var itemOutVertex = _graph.Vertices
                                        .Where(v => v.Id.ToString().Equals(itemTargetId))
                                        .SingleOrDefault();

            var associationEdge = _graph.AddEdge(itemOutVertex, itemInVertex, EdgeId.NewEdgeId, "", null);
            return new Association(this, associationEdge.Id.ToString());
        }

        public void RemoveAssocation(string id)
        {
            var edge = _graph.GetEdge(new EdgeId(id));
            _graph.RemoveEdge(edge);
        }

        public Association GetAssocation(string id)
        {
            return new Association(this, id);
        }

        public IEnumerable<Association> Associations
        {
            get
            {
                return _graph.Edges
                        .Where(v => v.InVertex.Data.Type.Equals(VertexType.Item) &&
                                    v.OutVertex.Data.Type.Equals( VertexType.Item))
                        .Select(v => new Association(this, v.Id.ToString()));
            }
        }

        #endregion

        #region InstanceAssociation

        public InstanceAssociation AddInstanceAssocation(string metaItemSourceId, string itemTargetId)
        {
            var instanceItemInVertex = _graph.Vertices
                                        .Where(v => v.Id.ToString().Equals(metaItemSourceId))
                                        .SingleOrDefault();

            var instanceItemOutVertex = _graph.Vertices
                                        .Where(v => v.Id.ToString().Equals(itemTargetId))
                                        .SingleOrDefault();

            var instanceAssociation = _graph.AddEdge(instanceItemOutVertex, instanceItemInVertex, EdgeId.NewEdgeId, "", null);
            return new InstanceAssociation(this, instanceAssociation.Id.ToString());
        }

        public void RemoveInstanceAssocation(string id)
        {
            var edge = _graph.GetEdge(new EdgeId(id));
            _graph.RemoveEdge(edge);
        }

        public InstanceAssociation GetInstanceAssocation(string id)
        {
            return new InstanceAssociation(this, id);
        }

        public IEnumerable<InstanceAssociation> InstanceAssociations
        {
            get
            {
                return _graph.Edges
                        .Where(v => v.InVertex.Data.Type.Equals(VertexType.MetaItem) &&
                                    v.OutVertex.Data.Type.Equals(VertexType.Item))
                        .Select(v => new InstanceAssociation(this, v.Id.ToString()));
            }
        }

        #endregion

        IHaymanVertex IModelGraphAdapter.GetVertex(VertexId id)
        {
            return _graph.GetVertex(id);
        }

        IHaymanEdge IModelGraphAdapter.GetEdge(EdgeId id)
        {
            return _graph.GetEdge(id);
        }

		public override string ToString()
		{
			return Name;
		}
    }
}
