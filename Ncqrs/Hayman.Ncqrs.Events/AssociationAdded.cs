using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Events
{
	public class AssociationAdded : SourcedEvent
	{
        public Guid AssociationId { get; private set; }
        public Guid ItemSourceId { get; private set; }
        public Guid ItemTargetId { get; private set; }
        public String AssociationName { get; private set; }

        public AssociationAdded(Guid associationId, Guid itemSourceId, Guid itemTargetId, String associationName)
        {
            AssociationId = associationId;
            ItemSourceId = itemSourceId;
            ItemTargetId = itemTargetId;
            AssociationName = associationName;
        }
    }
}
