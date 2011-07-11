using System;
using Ncqrs.Commanding;

namespace Hayman.Ncqrs.Commands
{
	[Serializable]
    //[MapsToAggregateRootConstructor("Hayman.Domain.MetaModel, Hayman.Domain")]
	public class AddMetaItem : CommandBase
	{
        public Guid MetaModelId { get; private set; }
        public Guid MetaItemId { get; private set; }
        public string MetaItemName { get; private set; }
        
        public AddMetaItem(Guid metaModelId, Guid metaItemId, string metaItemName)
        {
            MetaModelId = metaModelId;
            MetaItemId = metaItemId;
            MetaItemName = metaItemName;
        }
	}
}
