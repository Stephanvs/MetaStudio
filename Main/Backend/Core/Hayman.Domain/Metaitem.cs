using System;
using Ncqrs.Domain;
using Hayman.Events;

namespace Hayman.Domain
{
    public class Metaitem : EntityMappedByConvention
	{
        public MetaModel MetaModel { get; set; }
        public string MetaitemName { get; set; }

        public Metaitem(MetaModel metaModel, Guid metaitemid, string metaitemName)
            : base(metaModel, metaitemid)
        {
            ApplyEvent(new MetaitemAdded(metaitemid, metaitemName, metaModel.EventSourceId));			
        }
        
        private void OnMetaitemAdded(MetaitemAdded e)
        {
            MetaitemName = e.MetaitemName;
        }		
	}
}
