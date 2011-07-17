using System;
using Ncqrs.Domain;

namespace Hayman.Domain
{
    public class Item : EntityMappedByConvention
	{
        private MetaItem metaItem;
        private Guid itemId;
        private string itemName;

        public Item(Model model, MetaItem metaItem, Guid itemId, string itemName)
            : base(model, itemId)
        {
            this.metaItem = metaItem;
            this.itemId = itemId;
            this.itemName = itemName;
        }
	}
}
