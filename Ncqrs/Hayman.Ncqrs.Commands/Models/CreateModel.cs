using System;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Hayman.Commands.Models
{
	[Serializable]
	[MapsToAggregateRootConstructor("Hayman.Domain.Model, Hayman.Domain")]
	public class CreateModel : CommandBase
	{
		public Guid ModelId { get; set; }
		public string ModelName { get; private set; }

		public CreateModel(Guid modelId, string modelName)
		{
			ModelId = modelId;
			ModelName = modelName;
		}
	}
}