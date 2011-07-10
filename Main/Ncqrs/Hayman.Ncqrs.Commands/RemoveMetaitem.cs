using System;
using Ncqrs.Commanding;

namespace Hayman.Ncqrs.Commands
{
	[Serializable]
	public class RemoveMetaItem : CommandBase
	{
        public Guid MetaModelId { get; private set; }
        public Guid MetaItemId { get; private set; }

        public RemoveMetaItem(Guid metaModelId, Guid metaItemId)
        {
            MetaModelId = metaModelId;
            MetaItemId = metaItemId;
        }
	}
}