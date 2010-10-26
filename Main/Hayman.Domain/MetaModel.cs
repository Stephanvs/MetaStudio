using System;
using Ncqrs.Domain;
using Hayman.Events;
using System.Collections.Generic;
using System.Linq;

namespace Hayman.Domain
{
    public class MetaModel : AggregateRootMappedByConvention
	{
        private string metaModelName;
        private IList<MetaItem> metaItems;
        private bool deleted;
        
        protected MetaModel()
        { 
        }

		public MetaModel(Guid metaModelId, string metaModelName) : base(metaModelId)
		{
            ApplyEvent(new MetaModelCreated(metaModelId, metaModelName));
		}

        public void Rename(string newMetaModelName)
        {
            if (deleted)
            {
                throw new MetaModelDeletedException();
            }

            ApplyEvent(new MetaModelRenamed(newMetaModelName)); 
        }

        public void Delete()
        {
            if (deleted)
            {
                throw new MetaModelDeletedException();
            }

            ApplyEvent(new MetaModelDeleted(EventSourceId)); 
        }

		public void AddMetaItem(Guid metaItemId, string metaItemName)
		{
            if (deleted)
            {
                throw new MetaModelDeletedException();
            }

            if (!metaItems.Any(i => i.EntityId == metaItemId))
            {
                ApplyEvent(new MetaItemAdded(metaItemId, metaItemName, EventSourceId));
            }
		}

        public void RemoveMetaItem(Guid metaItemId)
        {
            if (deleted)
            {
                throw new MetaModelDeletedException();
            }

            if (metaItems.Any(i => i.EntityId == metaItemId))
            {
                ApplyEvent(new MetaItemRemoved(metaItemId, EventSourceId));
            }
        }

        public bool ContainsMetaItem(Guid metaItemId)
        {
            return metaItems.Any(i => i.EntityId == metaItemId);
        }

        private void OnMetaModelCreated(MetaModelCreated e)
		{
			metaModelName = e.MetaModelName;
            metaItems = new List<MetaItem>();
            deleted = false;
		}

        private void OnMetaModelDeleted(MetaModelDeleted e)
        {
            deleted = true;
        }

        private void OnMetaModelRenamed(MetaModelRenamed e)
        {
            metaModelName = e.NewMetaModelName;
        }

        private void OnMetaItemAdded(MetaItemAdded e)
		{
            metaItems.Add(new MetaItem(this, e.MetaItemId, e.MetaItemName));
		}

        private void OnMetaItemRemoved(MetaItemRemoved e)
        {
            MetaItem metaItem = metaItems.Where(m => m.EntityId == e.MetaItemId).SingleOrDefault();
            metaItems.Remove(metaItem);
        }
	}
}
