using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Events
{
	public class MetaitemAdded : SourcedEntityEvent
	{
        public Guid MetaitemId { get; set; }
        public String MetaitemName { get; set; }
        public Guid MetaModelId { get; set; }

        public MetaitemAdded(Guid metaitemId, String metaitemName, Guid metaModelId)
        {
            MetaitemId = metaitemId;
            MetaitemName = metaitemName;
            MetaModelId = metaModelId;
        }
    }
}
