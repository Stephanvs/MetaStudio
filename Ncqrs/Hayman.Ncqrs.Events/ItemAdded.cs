using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Events
{
	public class ItemAdded : EntitySourcedEventBase
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
