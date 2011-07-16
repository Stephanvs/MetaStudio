using System;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Hayman.Commands
{
	[Serializable]
	[MapsToAggregateRootConstructor("Hayman.Domain.MetaModel, Hayman.Domain")]
	public class CreateModel : CommandBase
	{
		public Guid MetaModelId { get; set; }
		public string MetaModelName { get; private set; }

		public CreateModel(Guid metaModelId, string metaModelName)
		{
			MetaModelId = metaModelId;
			MetaModelName = metaModelName;
		}
	}
}