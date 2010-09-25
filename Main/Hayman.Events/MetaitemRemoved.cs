using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Events
{
	[Serializable]
	public class MetaitemRemoved : SourcedEntityEvent
	{
        public Guid MetaitemId { get; set; }
        public Guid MetaModelId { get; set; }

        public MetaitemRemoved(Guid metaitemId, Guid metaModelId)
        {
            MetaitemId = metaitemId;
            MetaModelId = metaModelId;
        }
	}
}
