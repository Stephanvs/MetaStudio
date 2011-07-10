using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Ncqrs.Events
{
	[Serializable]
	public class AssociationRemoved : SourcedEntityEvent
	{
        public Guid AssociationId { get; private set; }

        public AssociationRemoved(Guid associationId)
        {
            AssociationId = associationId;
        }
	}
}
