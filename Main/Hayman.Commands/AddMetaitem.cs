using System;
using Ncqrs.Commanding;

namespace Hayman.Commands
{
	[Serializable]
    //[MapsToAggregateRootConstructor("Hayman.Domain.MetaModel, Hayman.Domain")]
	public class AddMetaitem : CommandBase
	{
        public Guid MetaModelId { get; private set; }
        public Guid MetaitemId { get; private set; }
        public string MetaitemName { get; private set; }
        
        public AddMetaitem(Guid metaModelId, Guid metaItemId, string metaitemName)
        {
            MetaModelId = metaModelId;
            MetaitemId = metaItemId;
            MetaitemName = metaitemName;
        }
	}
}
