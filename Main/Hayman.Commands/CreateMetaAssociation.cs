using System;
using Ncqrs.Commanding;

namespace Hayman.Commands
{
	[Serializable]
	//[MapsToAggregateRootMethod(typeof(MetaModel))]
	public class CreateMetaAssociation : CommandBase
	{
        public Guid MetaAssociationId { get; private set; }
        public Guid MetaitemSourceId { get; private set; }
        public Guid MetaitemTargetId { get; private set; }

        public CreateMetaAssociation(Guid metaModelId, Guid metaAssociationId, Guid metaitemSourceId, Guid metaItemTargetId)
		{
            MetaAssociationId = metaAssociationId;
            MetaitemSourceId = metaitemSourceId;
			MetaitemTargetId = metaItemTargetId;
		}
	}
}
