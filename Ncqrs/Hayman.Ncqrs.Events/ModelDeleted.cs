using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Events
{
	[Serializable]
	public class ModelDeleted : SourcedEvent
    {
        public Guid MetaModelId { get; private set; }

        public ModelDeleted(Guid metaModelId)
        {
            MetaModelId = metaModelId;
        }
    }
}
