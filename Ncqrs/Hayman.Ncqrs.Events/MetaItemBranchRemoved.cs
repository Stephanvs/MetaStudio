using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Events
{
	public class MetaItemBranchRemoved : SourcedEvent
	{
        public Guid MetaItemBranchId { get; private set; }

        public MetaItemBranchRemoved(Guid metaItemBranchId)
        {
            MetaItemBranchId = metaItemBranchId;
        }
    }
}
