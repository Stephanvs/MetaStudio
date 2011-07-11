using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Ncqrs.Events
{
	public class MetaAssociationDeleted : SourcedEvent
	{
        public Guid MetaAssociationId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the MetaAssociationCreated class.
        /// </summary>
        public MetaAssociationDeleted(Guid metaAssociationId)
        {
            MetaAssociationId = metaAssociationId;
        }
    }
}
