using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Ncqrs.Events
{
    [Serializable]
    public class MetaModelAlreadyDeleted : SourcedEvent
    {
        public Guid MetaModelId { get; private set; }

        public MetaModelAlreadyDeleted(Guid metaModelId)
        {
            MetaModelId = metaModelId;
        }
    }
}
