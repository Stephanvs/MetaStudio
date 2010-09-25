using System;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Hayman.Commands
{
	[Serializable]
	[MapsToAggregateRootConstructor("Hayman.Domain.Model, Hayman.Domain")]
	public class CreateMetaModelCommand : CommandBase
	{
		public CreateMetaModelCommand(string name)
		{
            Id = Guid.NewGuid();
			Name = name;
		}

        public Guid Id { get; private set; }
		public string Name { get; private set; }
	}
}