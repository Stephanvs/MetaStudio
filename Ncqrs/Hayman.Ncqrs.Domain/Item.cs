using System;
using Ncqrs.Domain;

namespace Hayman.Domain
{
    public class Item : EntityMappedByConvention
	{
        private MetaItem metaItem;
        private Guid itemId;
        private string itemName;

        public Item(MetaModel metaModel, MetaItem metaItem, Guid itemId, string itemName)
            : base(metaModel, itemId)
        {
            this.metaItem = metaItem;
            this.itemId = itemId;
            this.itemName = itemName;
        }
	}
}
