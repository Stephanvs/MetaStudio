using System;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Hayman.Ncqrs.Commands
{
	[Serializable]
    [MapsToAggregateRootMethod("Hayman.Domain.MetaModel, Hayman.Domain", "Rename")]
	public class RenameMetaModel : CommandBase
	{
        [AggregateRootId]
        public Guid MetaModelId { get; private set; }

        public string NewMetaModelName { get; private set; }

        public RenameMetaModel(Guid metaModelId, string newMetaModelName)
		{
            MetaModelId = metaModelId;
			NewMetaModelName = newMetaModelName;
		}
	}
}