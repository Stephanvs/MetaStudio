using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Events
{
	[Serializable]
	public class MetaModelDeleted : SourcedEvent
    {
        public Guid MetaModelId { get; private set; }

        public MetaModelDeleted(Guid metaModelId)
        {
            MetaModelId = metaModelId;
        }
    }
}
