using System;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Hayman.Commands.Models
{
	[Serializable]
    [MapsToAggregateRootMethod("Hayman.Domain.Model, Hayman.Domain", "Rename")]
	public class RenameModel : CommandBase
	{
        [AggregateRootId]
        public Guid ModelId { get; private set; }

        public string NewModelName { get; private set; }

        public RenameModel(Guid modelId, string newModelName)
		{
            ModelId = modelId;
			NewModelName = newModelName;
		}
	}
}