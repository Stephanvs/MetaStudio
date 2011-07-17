using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Events
{
    [Serializable]
	public class ModelAlreadyDeleted : SourcedEvent
    {
        public Guid MetaModelId { get; private set; }

        public ModelAlreadyDeleted(Guid metaModelId)
        {
            MetaModelId = metaModelId;
        }
    }
}
