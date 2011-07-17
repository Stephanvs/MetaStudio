using System;
using Ncqrs.Commanding;

namespace Hayman.Commands.Associations
{
	[Serializable]
	//[MapsToAggregateRootMethod(typeof(MetaModel))]
    public class DeleteMetaAssociation : CommandBase
	{
        public Guid MetaAssociationId { get; private set; }

        public DeleteMetaAssociation(Guid metaAssociationId)
		{
            MetaAssociationId = metaAssociationId;
		}
	}
}
