using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Events
{
	public class MetaItemBranchAdded : SourcedEntityEvent
	{
        public Guid MetaItemBranchId { get; private set; }
        public Guid BranchedOnMetaItemId { get; private set; }

        public MetaItemBranchAdded(Guid metaItemBranchId, Guid branchedOnMetaItemId)
        {
            MetaItemBranchId = metaItemBranchId;
            BranchedOnMetaItemId = branchedOnMetaItemId;
        }
    }
}
