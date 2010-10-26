using System;
using Ncqrs.Domain;
using Hayman.Events;

namespace Hayman.Domain
{
    public class MetaItem : EntityMappedByConvention
	{
        public MetaModel MetaModel { get; set; }
        public string MetaItemName { get; set; }

        public MetaItem(MetaModel metaModel, Guid metaItemId, string metaItemName)
            : base(metaModel, metaItemId)
        {
            MetaItemName = metaItemName;
            MetaModel = metaModel;
        }

        private void OnMetaItemAdded(MetaItemAdded e)
        {
            MetaItemName = e.MetaItemName;
        }
	}
}
