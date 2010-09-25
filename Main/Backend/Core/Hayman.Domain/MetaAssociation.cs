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

        protected MetaAssociation()
        {
        }

        public MetaAssociation(Guid metaAssociationId, Guid metaitemSourceId, Guid metaitemTargetId) : base(metaAssociationId)
		{
            ApplyEvent(new MetaAssociationAdded(metaAssociationId, metaitemSourceId, metaitemTargetId));			
		}

		private void OnMetaAssociationAdded(MetaAssociationAdded e)
		{
			MetaAssociationId = e.MetaAssociationId;
			MetaitemSourceId = e.MetaitemSourceId;
            MetaitemTargetId = e.MetaitemTargetId;
		}
	}
}
