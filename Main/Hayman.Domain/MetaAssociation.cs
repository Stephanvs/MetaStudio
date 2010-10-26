using System;
using Ncqrs.Domain;
using Hayman.Events;

namespace Hayman.Domain
{
    public class MetaAssociation : AggregateRootMappedByConvention
	{
        private Guid metaItemSourceId { get; set; }
        private Guid metaItemTargetId { get; set; }
        private bool deleted { get; set; }

        protected MetaAssociation()
        { 
        }

        public MetaAssociation(Guid metaAssociationId, Guid metaItemSourceId, Guid metaItemTargetId)
            : base(metaAssociationId)
		{
            if (deleted)
            {
                throw new MetaAssociationDeletedException();
            }

            ApplyEvent(new MetaAssociationCreated(metaAssociationId, metaItemSourceId, metaItemTargetId));
		}

        public void Delete()
        {
            if (deleted)
            {
                throw new MetaAssociationDeletedException();
            }

            ApplyEvent(new MetaAssociationDeleted(EventSourceId));
        }

        private void OnMetaAssociationCreated(MetaAssociationCreated e)
		{
			metaItemSourceId = e.MetaItemSourceId;
            metaItemTargetId = e.MetaItemTargetId;
		}

        private void OnMetaAssociationDeleted(MetaAssociationDeleted e)
        {
            deleted = true;
        }
	}
}
