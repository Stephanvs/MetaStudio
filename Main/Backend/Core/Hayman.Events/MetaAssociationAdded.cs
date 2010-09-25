using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Events
{
    public class MetaAssociationAdded : SourcedEntityEvent
	{
		public Guid MetaAssociationId { get; set; }
		public Guid MetaitemSourceId { get; set; }
		public Guid MetaitemTargetId { get; set; }

        /// <summary>
        /// Initializes a new instance of the MetaAssociationAdded class.
        /// </summary>
        public MetaAssociationAdded(Guid metaAssociationId, Guid metaitemSourceId, Guid metaitemTargetId)
        {
            MetaAssociationId = metaAssociationId;
            MetaitemSourceId = metaitemSourceId;
            MetaitemTargetId = metaitemTargetId;
        }
    }
}
