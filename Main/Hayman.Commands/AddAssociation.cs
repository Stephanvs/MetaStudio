using System;
using Ncqrs.Commanding;

namespace Hayman.Commands
{
	[Serializable]
	public class AddAssociation : CommandBase
	{
        public Guid MetaAssociationId { get; private set; }
        public Guid AssociationId { get; private set; }
        public string AssociationName { get; private set; }

        public AddAssociation(Guid metaAssociationId, Guid associationId, string associationName)
        {
            MetaAssociationId = metaAssociationId;
            AssociationId = associationId;
            AssociationName = associationName;
        }
	}
}
