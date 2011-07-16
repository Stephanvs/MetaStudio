using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Events
{
    [Serializable]
    public class ModelCreated : SourcedEvent
    {
        public Guid MetaModelId { get; private set; }
        public String MetaModelName { get; private set; }

        public ModelCreated(Guid metaModelId, String metaModelName)
        {
            MetaModelId = metaModelId;
            MetaModelName = metaModelName;
        }
    }
}
