using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Ncqrs.Events
{
	public class MetaAssociationCreated : SourcedEvent
	{
        public Guid MetaAssociationId { get; private set; }
        public Guid MetaItemSourceId { get; private set; }
        public Guid MetaItemTargetId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the MetaAssociationCreated class.
        /// </summary>
        public MetaAssociationCreated(Guid metaAssociationId, Guid metaItemSourceId, Guid metaItemTargetId)
        {
            MetaAssociationId = metaAssociationId;
            MetaItemSourceId = metaItemSourceId;
            MetaItemTargetId = metaItemTargetId;
        }
    }
}
