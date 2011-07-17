using System;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Hayman.Commands.MetaItems
{
	[Serializable]
    [MapsToAggregateRootMethod("Hayman.Domain.Model, Hayman.Domain", "AddMetaItem")]
	public class AddMetaItem : CommandBase
	{
		[AggregateRootId]
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
