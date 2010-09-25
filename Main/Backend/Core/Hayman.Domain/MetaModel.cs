using System;
using Ncqrs.Domain;
using Hayman.Events;
using System.Collections.Generic;
using System.Linq;

namespace Hayman.Domain
{
    public class MetaModel : AggregateRootMappedByConvention
	{
        private string metaModelName;
        private IList<Metaitem> metaitems;

        protected MetaModel()
        { 
        }

		public MetaModel(Guid metaModelId, string metaModelName) : base(metaModelId)
		{
            ApplyEvent(new MetaModelCreated(metaModelId, metaModelName));
		}

        public void Rename(string newMetaModelName)
        { 
            ApplyEvent(new MetaModelRenamed(newMetaModelName)); 
        }

		public void AddMetaitem(Guid metaitemId, string metaitemName)
		{
            if (!metaitems.Any(i => i.EntityId == metaitemId))
            {
                ApplyEvent(new MetaitemAdded(metaitemId, metaitemName, EventSourceId));
            }
		}

        public void RemoveMetaitem(Guid metaitemId)
        {
            if (metaitems.Any(i => i.EntityId == metaitemId))
            {
                ApplyEvent(new MetaitemRemoved(metaitemId, EventSourceId));
            }
        }

        public bool ContainsMetaitem(Guid metaitemId)
        {
            return metaitems.Any(i => i.EntityId == metaitemId);
        }

        public void AddMetaAssociation(Guid metaAssociationId, Guid metaitemSourceId, Guid metaitemTargetId)
        {
            Metaitem metaitem = metaitems.Where(m => m.EntityId == metaitemSourceId).SingleOrDefault();
            metaitem.AddMetaAssociation(metaAssociationId, metaitemTargetId);
        }

        private void OnMetaModelCreated(MetaModelCreated e)
		{
			metaModelName = e.MetaModelName;
            metaitems = new List<Metaitem>();
		}

        private void OnMetaModelRenamed(MetaModelRenamed e)
        {
            metaModelName = e.NewMetaModelName;
        }

		private void OnMetaitemAdded(MetaitemAdded e)
		{
            metaitems.Add(new Metaitem(this, e.MetaitemId, e.MetaitemName));
		}

        private void OnMetaitemRemoved(MetaitemRemoved e)
        {
            Metaitem metaitem = metaitems.Where(m => m.EntityId == e.MetaitemId).SingleOrDefault();
            metaitems.Remove(metaitem);
        }
	}
}
