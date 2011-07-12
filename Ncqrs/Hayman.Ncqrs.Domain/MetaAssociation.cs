using System;
using Hayman.Domain.Snapshotting;
using Ncqrs.Domain;
using Hayman.Events;
using System.Collections.Generic;
using System.Linq;
using Ncqrs.Eventing.Sourcing.Snapshotting;

namespace Hayman.Domain
{
    public class MetaAssociation : AggregateRootMappedByConvention, ISnapshotable<MetaAssociationSnapshot>
	{
        private Guid metaItemSourceId;
        private Guid metaItemTargetId;
        private List<Association> associations;
        private bool deleted;

        protected MetaAssociation()
        { 
        }

        public MetaAssociation(Guid metaAssociationId, Guid metaItemSourceId, Guid metaItemTargetId)
            : base(metaAssociationId)
		{
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

        public void AddAssociation(Guid associationId, Guid itemSourceId, Guid itemTargetId, string associationName)
        {
            if (deleted)
            {
                throw new MetaAssociationDeletedException();
            }

            if (!associations.Any(a => a.EntityId == associationId))
            {
                ApplyEvent(new AssociationAdded(associationId, itemSourceId, itemTargetId, associationName));
            }
        }

        public void RemoveAssociation(Guid associationId)
        {
            if (deleted)
            {
                throw new MetaAssociationDeletedException();
            }

            if (associations.Any(a => a.EntityId == associationId))
            {
                ApplyEvent(new AssociationRemoved(associationId));
            }
        }

        public bool ContainsAssociation(Guid associationd)
        {
            return associations.Any(a => a.EntityId == associationd);
        }

        #region EventHandlers

        private void OnMetaAssociationCreated(MetaAssociationCreated e)
        {
            metaItemSourceId = e.MetaItemSourceId;
            metaItemTargetId = e.MetaItemTargetId;
            associations = new List<Association>();
        }

        private void OnMetaAssociationDeleted(MetaAssociationDeleted e)
        {
            deleted = true;
        }

        private void OnAssociationAdded(AssociationAdded e)
        {
            associations.Add(new Association(this, e.AssociationId, e.ItemSourceId, e.ItemTargetId, e.AssociationName));
        }

        private void OnAssociationRemoved(AssociationRemoved e)
        {
            Association association = associations.Where(a => a.EntityId == e.AssociationId).SingleOrDefault();
            associations.Remove(association);
        }

        #endregion

        #region ISnapshotable<MetaAssociationSnapshot>
        
        public MetaAssociationSnapshot CreateSnapshot()
        {
            return new MetaAssociationSnapshot
            {
				//EventSourceId = EventSourceId,
				//Version = Version,
                MetaItemSourceId = metaItemSourceId,
                MetaItemTargetId = metaItemTargetId,
                Associations = associations,
                Deleted = deleted
            };
        }

        public void RestoreFromSnapshot(MetaAssociationSnapshot snapshot)
        {
        	InitializeFromSnapshot(snapshot);
        }

        #endregion
    }
}
