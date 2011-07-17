using System;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Hayman.Commands.MetaItems
{
	[Serializable]
	[MapsToAggregateRootMethod("Hayman.Domain.Model, Hayman.Domain", "RemoveMetaItem")]
	public class RemoveMetaItem : CommandBase
	{
		[AggregateRootId]
        public Guid ModelId { get; private set; }
        public Guid MetaItemId { get; private set; }

        public RemoveMetaItem(Guid modelId, Guid metaItemId)
        {
            ModelId = modelId;
            MetaItemId = metaItemId;
        }
	}
}