using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Events
{
	[Serializable]
	public class MetaItemRemoved : SourcedEntityEvent
	{
        public Guid MetaItemId { get; private set; }

        public MetaItemRemoved(Guid metaItemId)
        {
            MetaItemId = metaItemId;
        }
	}
}
