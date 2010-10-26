using System;
using Ncqrs.Commanding;

namespace Hayman.Commands
{
	[Serializable]
	//[MapsToAggregateRootConstructor("Hayman.Domain.MetaModel, Hayman.Domain")]
	public class DeleteMetaModel : CommandBase
	{
        public Guid MetaModelId { get; private set; }

        public DeleteMetaModel(Guid metaModelId)
		{
            MetaModelId = metaModelId;
		}
	}
}