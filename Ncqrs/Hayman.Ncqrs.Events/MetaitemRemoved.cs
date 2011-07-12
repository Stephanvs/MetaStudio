using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Events
{
	[Serializable]
	public class MetaItemRemoved : SourcedEvent
	{
        public Guid MetaItemId { get; private set; }

        public MetaItemRemoved(Guid metaItemId)
        {
            MetaItemId = metaItemId;
        }
	}
}
