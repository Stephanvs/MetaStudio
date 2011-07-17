using System;
using Ncqrs.Domain;
using Hayman.Events;
using System.Collections.Generic;
using System.Linq;

namespace Hayman.Domain
{
    public class MetaItem : EntityMappedByConvention
	{
        private string metaItemName;
        private List<Item> items = new List<Item>();
        private Guid metaItemBranchId;
        

        public MetaItem(Model model, Guid metaItemId, string metaItemName, Guid metaItemBranchId)
            : base(model, metaItemId)
        {
            this.metaItemName = metaItemName;
            this.metaItemBranchId = metaItemBranchId;
        }

        public void AddItem(Guid itemId, string itemName)
        {
            if (((Model)ParentAggregateRoot).IsDeleted())
            {
                throw new ModelDeletedException();
            }

            if (!items.Any(i => i.EntityId == itemId))
            {
                ApplyEvent(new ItemAdded(itemId, itemName));
            }
        }

        public void RemoveItem(Guid itemId)
        {
            if (((Model)ParentAggregateRoot).IsDeleted())
            {
                throw new ModelDeletedException();
            }

            if (!items.Any(i => i.EntityId == itemId))
            {
                ApplyEvent(new ItemRemoved(itemId));
            }
        }

        #region EventHandlers
        
        private void OnItemAdded(ItemAdded e)
        {
            items.Add(new Item((Model)ParentAggregateRoot, this, e.ItemId, e.ItemName));
        }

        private void OnItemRemoved(ItemRemoved e)
        {
            Item item = items.Where(m => m.EntityId == e.ItemId).SingleOrDefault();
            items.Remove(item);
        }

        #endregion
    }
}
