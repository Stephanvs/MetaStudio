using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Events
{
    [Serializable]
    public class MetaModelCreated : SourcedEvent
    {
        public Guid MetaModelId { get; private set; }
        public String MetaModelName { get; private set; }

        public MetaModelCreated(Guid metaModelId, String metaModelName)
        {
            MetaModelId = metaModelId;
            MetaModelName = metaModelName;
        }
    }
}
