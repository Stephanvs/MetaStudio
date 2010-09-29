using System;
using System.Collections.Generic;
using Ncqrs.Domain;
using Hayman.Events;
using System.Linq;

namespace Hayman.Domain
{
    public class Metaitem : EntityMappedByConvention
	{
        public MetaModel MetaModel { get; set; }
        public string MetaitemName { get; set; }

        public Metaitem(MetaModel metaModel, Guid metaitemid, string metaitemName)
            : base(metaModel, metaitemid)
        {
            MetaitemName = metaitemName;
            MetaModel = metaModel;
        }

        private void OnMetaitemAdded(MetaitemAdded e)
        {
            MetaitemName = e.MetaitemName;
        }
	}
}
