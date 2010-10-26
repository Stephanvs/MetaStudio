using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Events
{
	[Serializable]
	public class MetaItemRemoved : SourcedEntityEvent
	{
        public Guid MetaItemId { get; set; }
        public Guid MetaModelId { get; set; }

        public MetaItemRemoved(Guid metaItemId, Guid metaModelId)
        {
            MetaItemId = metaItemId;
            MetaModelId = metaModelId;
        }
	}
}
