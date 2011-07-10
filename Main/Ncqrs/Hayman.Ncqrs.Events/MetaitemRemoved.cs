using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Ncqrs.Events
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
