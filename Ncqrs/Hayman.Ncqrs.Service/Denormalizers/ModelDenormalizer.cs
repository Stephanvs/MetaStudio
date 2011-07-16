using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hayman.Events;
using Ncqrs.Eventing.ServiceModel.Bus;

namespace Hayman.Service.Denormalizers
{
	public class ModelDenormalizer : IEventHandler<ModelCreated>
	{
		public void Handle(IPublishedEvent<ModelCreated> evnt)
		{
			Console.WriteLine("ID: {0}, ModelId: {1}, ModelName: {2}", evnt.EventIdentifier, evnt.Payload.MetaModelId, evnt.Payload.MetaModelName);
		}
	}
}
