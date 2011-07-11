using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Ncqrs.Events
{
	[Serializable]
	public class MetaModelRenamed : SourcedEvent
    {
        public Guid MetaModelId { get; private set; }
        public String NewMetaModelName { get; private set; }

        public MetaModelRenamed(Guid metaModelId, String newMetaModelName)
        {
            MetaModelId = metaModelId;
            NewMetaModelName = newMetaModelName;
        }
    }
}
