using System;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Hayman.Commands.Models
{
	[Serializable]
    [MapsToAggregateRootMethod("Hayman.Domain.Model, Hayman.Domain", "Delete")]
	public class DeleteModel : CommandBase
	{
        [AggregateRootId]
        public Guid ModelId { get; private set; }

        public DeleteModel(Guid modelId) 
			: base(modelId)
		{
            ModelId = modelId;
        }
	}
}