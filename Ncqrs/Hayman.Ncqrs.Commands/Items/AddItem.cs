using System;
using Ncqrs.Commanding;

namespace Hayman.Commands.Items
{
	[Serializable]
	public class AddItem : CommandBase
	{
        public Guid ModelId { get; private set; }
        public Guid MetaItemId { get; private set; }
        public Guid ItemId { get; private set; }
        public string ItemName { get; private set; }
        
        public AddItem(Guid modelId, Guid metaItemId, Guid itemId, string itemName)
        {
            ModelId = modelId;
            MetaItemId = metaItemId;
            ItemId = itemId;
            ItemName = itemName;
        }
	}
}
