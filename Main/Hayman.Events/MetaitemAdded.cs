using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Events
{
	public class MetaItemAdded : SourcedEntityEvent
	{
        public Guid MetaItemId { get; set; }
        public String MetaItemName { get; set; }
        public Guid MetaModelId { get; set; }

        public MetaItemAdded(Guid metaItemId, String metaItemName, Guid metaModelId)
        {
            MetaItemId = metaItemId;
            MetaItemName = metaItemName;
            MetaModelId = metaModelId;
        }
    }
}
