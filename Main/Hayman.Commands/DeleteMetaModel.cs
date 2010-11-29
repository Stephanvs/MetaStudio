using System;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Hayman.Commands
{
	[Serializable]
    [MapsToAggregateRootMethod("Hayman.Domain.MetaModel, Hayman.Domain", "Delete")]
	public class DeleteMetaModel : CommandBase
	{
        [AggregateRootId]
        public Guid MetaModelId { get; private set; }

        public DeleteMetaModel(Guid metaModelId)
        {
            MetaModelId = metaModelId;
        }
	}
}