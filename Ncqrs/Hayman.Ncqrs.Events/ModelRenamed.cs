using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Events
{
	[Serializable]
	public class ModelRenamed : SourcedEvent
    {
        public Guid MetaModelId { get; private set; }
        public String NewMetaModelName { get; private set; }

        public ModelRenamed(Guid metaModelId, String newMetaModelName)
        {
            MetaModelId = metaModelId;
            NewMetaModelName = newMetaModelName;
        }
    }
}
