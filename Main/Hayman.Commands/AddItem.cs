using System;
using Ncqrs.Commanding;

namespace Hayman.Commands
{
	[Serializable]
	public class AddItem : CommandBase
	{
        public Guid MetaModelId { get; private set; }
        public Guid MetaItemId { get; private set; }
        public Guid ItemId { get; private set; }
        public string ItemName { get; private set; }
        
        public AddItem(Guid metaModelId, Guid metaItemId, Guid itemId, string itemName)
        {
            MetaModelId = metaModelId;
            MetaItemId = metaItemId;
            ItemId = itemId;
            ItemName = itemName;
        }
	}
}
