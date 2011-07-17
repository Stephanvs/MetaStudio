using System;
using Ncqrs.Commanding;

namespace Hayman.Commands.MetaItems
{
	[Serializable]
	public class RemoveMetaItem : CommandBase
	{
        public Guid ModelId { get; private set; }
        public Guid MetaItemId { get; private set; }

        public RemoveMetaItem(Guid modelId, Guid metaItemId)
        {
            ModelId = modelId;
            MetaItemId = metaItemId;
        }
	}
}