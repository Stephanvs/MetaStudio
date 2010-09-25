using System;
using Ncqrs.Commanding;

namespace Hayman.Commands
{
	[Serializable]
	public class RemoveMetaitem : CommandBase
	{
        public Guid MetaModelId { get; private set; }
        public Guid MetaitemId { get; private set; }

        public RemoveMetaitem(Guid metaModelId, Guid metaitemId)
        {
            MetaModelId = metaModelId;
            MetaitemId = metaitemId;
        }
	}
}