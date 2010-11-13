using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Events
{
	public class ItemRemoved : SourcedEntityEvent
	{
        public Guid ItemId { get; private set; }

        public ItemRemoved(Guid itemId)
        {
            ItemId = itemId;
        }
    }
}
