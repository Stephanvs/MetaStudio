using System;
using Ncqrs.Commanding;

namespace Hayman.Commands.MetaItems
{
	[Serializable]
    //[MapsToAggregateRootConstructor("Hayman.Domain.MetaModel, Hayman.Domain")]
	public class AddMetaItem : CommandBase
	{
        public Guid ModelId { get; private set; }
        public Guid MetaItemId { get; private set; }
        public string MetaItemName { get; private set; }
        
        public AddMetaItem(Guid modelId, Guid metaItemId, string metaItemName)
        {
            ModelId = modelId;
            MetaItemId = metaItemId;
            MetaItemName = metaItemName;
        }
	}
}
