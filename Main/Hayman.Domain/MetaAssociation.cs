using System;
using Ncqrs.Domain;
using Hayman.Events;

namespace Hayman.Domain
{
    public class MetaAssociation : AggregateRootMappedByConvention
	{
        public Guid MetaAssociationId { set; get; }
        public Guid MetaitemSourceId { get; set; }
        public Guid MetaitemTargetId { get; set; }

        public MetaAssociation(Guid metaAssociationId, Guid metaitemSourceId, Guid metaitemTargetId)
            : base(metaAssociationId)
		{
            ApplyEvent(new MetaAssociationCreated(metaAssociationId, metaitemSourceId, MetaitemTargetId));
		}

        private void OnMetaAssociationCreated(MetaAssociationCreated e)
		{
			MetaAssociationId = e.MetaAssociationId;
			MetaitemSourceId = e.MetaitemSourceId;
            MetaitemTargetId = e.MetaitemTargetId;
		}
	}
}
