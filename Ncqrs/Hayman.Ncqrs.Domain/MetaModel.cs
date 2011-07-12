using System;
using Hayman.Domain.Snapshotting;
using Ncqrs.Domain;
using Hayman.Events;
using System.Collections.Generic;
using System.Linq;
using Ncqrs.Eventing.Sourcing.Snapshotting;

namespace Hayman.Domain
{
    public class MetaModel : AggregateRootMappedByConvention, ISnapshotable<MetaModelSnapshot>
    {
        private string metaModelName;
        private IList<MetaItem> metaItems;
        private bool deleted;

        protected MetaModel()
        {
        }

        public MetaModel(Guid metaModelId, string metaModelName)
            : base(metaModelId)
        {
            ApplyEvent(new MetaModelCreated(metaModelId, metaModelName));
        }

        public void Rename(string newMetaModelName)
        {
            if (deleted)
            {
                throw new MetaModelDeletedException();
            }

            ApplyEvent(new MetaModelRenamed(EventSourceId, newMetaModelName));
        }

        public void Delete()
        {
            if (deleted)
            {
                ApplyEvent(new MetaModelAlreadyDeleted(EventSourceId));
                //throw new MetaModelDeletedException();
            }
            else
            {
                ApplyEvent(new MetaModelDeleted(EventSourceId));
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
                throw new MetaModelDeletedException();
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
                throw new MetaModelDeletedException();
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
            metaItems.Add(new MetaItem(this, e.MetaItemId, e.MetaItemName, e.MetaItemBranchId));
        }

        private void OnMetaItemRemoved(MetaItemRemoved e)
        {
            MetaItem metaItem = metaItems.Where(m => m.EntityId == e.MetaItemId).SingleOrDefault();
            metaItems.Remove(metaItem);
        }

        #endregion

        #region ISnapshotable<MetaModelSnapshot>

        public MetaModelSnapshot CreateSnapshot()
        {
            return new MetaModelSnapshot
            {
				//EventSourceId = EventSourceId,
				//Version = Version,
                MetaModelName = metaModelName,
                MetaItems = metaItems,
                Deleted = deleted
            };
        }

        public void RestoreFromSnapshot(MetaModelSnapshot snapshot)
        {
        	InitializeFromSnapshot(snapshot);
        }

        #endregion
    }
}
