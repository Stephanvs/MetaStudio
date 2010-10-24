using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Events
{
	public class MetaAssociationCreated : SourcedEvent
	{
        public Guid MetaAssociationId { get; set; }
        public Guid MetaitemSourceId { get; set; }
        public Guid MetaitemTargetId { get; set; }

        /// <summary>
        /// Initializes a new instance of the MetaAssociationCreated class.
        /// </summary>
        public MetaAssociationCreated(Guid metaAssociationId, Guid metaitemSourceId, Guid metaitemTargetId)
        {
            MetaAssociationId = metaAssociationId;
            MetaitemSourceId = metaitemSourceId;
            MetaitemTargetId = metaitemTargetId;
        }
    }
}
