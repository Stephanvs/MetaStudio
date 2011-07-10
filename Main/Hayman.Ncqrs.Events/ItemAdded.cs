using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Ncqrs.Events
{
	public class ItemAdded : SourcedEntityEvent
	{
        public Guid ItemId { get; private set; }
        public String ItemName { get; private set; }

        public ItemAdded(Guid itemId, String itemName)
        {
            ItemId = itemId;
            ItemName = itemName;
        }
    }
}
