using System;
using Ncqrs.Domain;
using Hayman.Ncqrs.Events;
using System.Collections.Generic;
using System.Linq;

namespace Hayman.Ncqrs.Domain
{
    public class MetaItem : EntityMappedByConvention
	{
        private string metaItemName;
        private List<Item> items = new List<Item>();
        private Guid metaItemBranchId;
        

        public MetaItem(MetaModel metaModel, Guid metaItemId, string metaItemName, Guid metaItemBranchId)
            : base(metaModel, metaItemId)
        {
            this.metaItemName = metaItemName;
            this.metaItemBranchId = metaItemBranchId;
        }

        public void AddItem(Guid itemId, string itemName)
        {
            if (((MetaModel)ParentAggregateRoot).IsDeleted())
            {
                throw new MetaModelDeletedException();
            }

            if (!items.Any(i => i.EntityId == itemId))
            {
                ApplyEvent(new ItemAdded(itemId, itemName));
            }
        }

        public void RemoveItem(Guid itemId)
        {
            if (((MetaModel)ParentAggregateRoot).IsDeleted())
            {
                throw new MetaModelDeletedException();
            }

            if (!items.Any(i => i.EntityId == itemId))
            {
                ApplyEvent(new ItemRemoved(itemId));
            }
        }

        #region EventHandlers
        
        private void OnItemAdded(ItemAdded e)
        {
            items.Add(new Item((MetaModel)ParentAggregateRoot, this, e.ItemId, e.ItemName));
        }

        private void OnItemRemoved(ItemRemoved e)
        {
            Item item = items.Where(m => m.EntityId == e.ItemId).SingleOrDefault();
            items.Remove(item);
        }

        #endregion
    }
}
