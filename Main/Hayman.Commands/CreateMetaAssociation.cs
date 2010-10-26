using System;
using Ncqrs.Commanding;

namespace Hayman.Commands
{
	[Serializable]
	//[MapsToAggregateRootMethod(typeof(MetaModel))]
	public class CreateMetaAssociation : CommandBase
	{
        public Guid MetaAssociationId { get; private set; }
        public Guid MetaItemSourceId { get; private set; }
        public Guid MetaItemTargetId { get; private set; }

        public CreateMetaAssociation(Guid metaAssociationId, Guid metaItemSourceId, Guid metaItemTargetId)
		{
            MetaAssociationId = metaAssociationId;
            MetaItemSourceId = metaItemSourceId;
			MetaItemTargetId = metaItemTargetId;
		}
	}
}
