using System;
using Ncqrs.Eventing.Sourcing;

namespace Hayman.Events
{
	[Serializable]
	public class AssociationRemoved : SourcedEvent
	{
        public Guid AssociationId { get; private set; }

        public AssociationRemoved(Guid associationId)
        {
            AssociationId = associationId;
        }
	}
}
