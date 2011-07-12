using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Events
{
	public class MetaItemAdded : SourcedEvent
	{
        public Guid MetaItemId { get; private set; }
        public String MetaItemName { get; private set; }
        public Guid MetaItemBranchId { get; private set; }

        public MetaItemAdded(Guid metaItemId, String metaItemName, Guid metaItemBranchId)
        {
            MetaItemId = metaItemId;
            MetaItemName = metaItemName;
            MetaItemBranchId = metaItemBranchId;
        }

        public MetaItemAdded(Guid metaItemId, String metaItemName)
        {
            MetaItemId = metaItemId;
            MetaItemName = metaItemName;
            MetaItemBranchId = Guid.Empty;
        }
    }
}
