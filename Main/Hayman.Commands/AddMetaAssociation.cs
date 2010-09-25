using System;
using Ncqrs.Commanding;

namespace Hayman.Commands
{
	[Serializable]
	//[MapsToAggregateRootMethod(typeof(MetaModel))]
	public class AddMetaAssociation : CommandBase
	{
        public Guid MetaModelId { get; private set; }
        public Guid MetaAssociationId { get; private set; }
        public Guid MetaitemSourceId { get; private set; }
        public Guid MetaitemTargetId { get; private set; }

        public AddMetaAssociation(Guid metaModelId, Guid metaAssociationId, Guid metaitemSourceId, Guid metaItemTargetId)
		{
            MetaModelId = metaModelId;
            MetaAssociationId = metaAssociationId;
            MetaitemSourceId = metaitemSourceId;
			MetaitemTargetId = metaItemTargetId;
		}
	}
}
