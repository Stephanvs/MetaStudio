using System;
using Ncqrs.Domain;
using Hayman.Events;

namespace Hayman.Domain
{
    public class MetaAssociation : AggregateRootMappedByConvention
	{
        public Guid MetaItemSourceId { get; set; }
        public Guid MetaItemTargetId { get; set; }
        public bool Deleted { get; private set; }

        protected MetaAssociation()
        { 
        }

        public MetaAssociation(Guid metaAssociationId, Guid metaItemSourceId, Guid metaItemTargetId)
            : base(metaAssociationId)
		{
            if (Deleted)
            {
                throw new MetaAssociationDeletedException();
            }

            ApplyEvent(new MetaAssociationCreated(metaAssociationId, metaItemSourceId, metaItemTargetId));
		}

        public void Delete()
        {
            if (Deleted)
            {
                throw new MetaAssociationDeletedException();
            }

            ApplyEvent(new MetaAssociationDeleted(EventSourceId));
        }

        private void OnMetaAssociationCreated(MetaAssociationCreated e)
		{
			MetaItemSourceId = e.MetaItemSourceId;
            MetaItemTargetId = e.MetaItemTargetId;
		}

        private void OnMetaAssociationDeleted(MetaAssociationDeleted e)
        {
            Deleted = true;
        }
	}
}
