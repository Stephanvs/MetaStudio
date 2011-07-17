using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hayman.Events;
using Ncqrs.Eventing.ServiceModel.Bus;

namespace Hayman.Service.Denormalizers
{
	public class ModelDenormalizer : 
		IEventHandler<ModelCreated>,
		IEventHandler<ModelRenamed>
	{
		#region IEventHandler<ModelCreated>

		public void Handle(IPublishedEvent<ModelCreated> evnt)
		{
			Console.WriteLine("ModelId: {0}, ModelName: {1}", evnt.Payload.ModelId, evnt.Payload.ModelName);
		}

		#endregion

		#region IEventHandler<ModelRenamed>

		public void Handle(IPublishedEvent<ModelRenamed> evnt)
		{
			Console.WriteLine("ModelId: {0}, New-ModelName: {1}", evnt.Payload.ModelId, evnt.Payload.NewModelName);
		}

		#endregion
	}
}
