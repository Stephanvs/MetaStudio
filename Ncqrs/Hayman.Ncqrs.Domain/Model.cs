using System;
using Hayman.Domain.Snapshotting;
using Ncqrs.Domain;
using Hayman.Events;
using System.Collections.Generic;
using System.Linq;
using Ncqrs.Eventing.Sourcing.Snapshotting;

namespace Hayman.Domain
{
    public class Model : AggregateRootMappedByConvention, ISnapshotable<ModelSnapshot>
    {
        private string modelName;
        private IList<MetaItem> metaItems;
        private bool deleted;

        protected Model() { }

        public Model(Guid modelId, string modelName)
            : base(modelId)
        {
            ApplyEvent(new ModelCreated(modelId, modelName));
        }

        public void Rename(string newModelName)
        {
            if (deleted)
            {
                throw new ModelDeletedException();
            }

            ApplyEvent(new ModelRenamed(EventSourceId, newModelName));
        }

        public void Delete()
        {
            if (deleted)
            {
                ApplyEvent(new ModelAlreadyDeleted(EventSourceId));
                //throw new ModelDeletedException();
            }
            else
            {
                ApplyEvent(new ModelDeleted(EventSourceId));
            }
        }

        public bool IsDeleted()
        {
            return deleted;
        }

        public void AddMetaItem(Guid metaItemId, string metaItemName)
        {
            if (deleted)
            {
                throw new ModelDeletedException();
            }

            if (!metaItems.Any(i => i.EntityId == metaItemId))
            {
                ApplyEvent(new MetaItemAdded(metaItemId, metaItemName));
            }
        }

        public void RemoveMetaItem(Guid metaItemId)
        {
            if (deleted)
            {
                throw new ModelDeletedException();
            }

            if (metaItems.Any(i => i.EntityId == metaItemId))
            {
                ApplyEvent(new MetaItemRemoved(metaItemId));
            }
        }

        public bool ContainsMetaItem(Guid metaItemId)
        {
            return metaItems.Any(i => i.EntityId == metaItemId);
        }

        public void AddItem(Guid metaItemId, Guid itemId, string itemName)
        {
            var metaItem = metaItems.Single(m => m.EntityId == metaItemId);
            metaItem.AddItem(itemId, itemName);
        }

        public void RemoveItem(Guid metaItemId, Guid itemId)
        {
            var metaItem = metaItems.Single(m => m.EntityId == metaItemId);
            metaItem.RemoveItem(itemId);
        }

        #region EventHandlers

        private void OnModelCreated(ModelCreated e)
        {
            modelName = e.ModelName;
            metaItems = new List<MetaItem>();
            deleted = false;
        }

        private void OnModelDeleted(ModelDeleted e)
        {
            deleted = true;
        }

        private void OnModelRenamed(ModelRenamed e)
        {
            modelName = e.NewMetaModelName;
        }

        private void OnMetaItemAdded(MetaItemAdded e)
        {
            metaItems.Add(new MetaItem(this, e.MetaItemId, e.MetaItemName, e.MetaItemBranchId));
        }

        private void OnMetaItemRemoved(MetaItemRemoved e)
        {
            MetaItem metaItem = metaItems.Where(m => m.EntityId == e.MetaItemId).SingleOrDefault();
            metaItems.Remove(metaItem);
        }

        #endregion

        #region ISnapshotable<ModelSnapshot>

        public ModelSnapshot CreateSnapshot()
        {
            return new ModelSnapshot
            {
				//EventSourceId = EventSourceId,
				//Version = Version,
                ModelName = modelName,
                MetaItems = metaItems,
                Deleted = deleted
            };
        }

        public void RestoreFromSnapshot(ModelSnapshot snapshot)
        {
        	InitializeFromSnapshot(snapshot);
        }

        #endregion
    }
}
