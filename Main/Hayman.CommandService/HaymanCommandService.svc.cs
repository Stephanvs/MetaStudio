using System;
using Hayman.Commands;
using Ncqrs.Commanding.ServiceModel;

namespace Hayman.CommandService
{
	public class HaymanCommandService : IHaymanCommandService
	{
		private static ICommandService _service;

		static HaymanCommandService()
		{
			Bootstrapper.BootUp();

			_service = Ncqrs.NcqrsEnvironment.Get<ICommandService>();
		}

		public void CreateModel(CreateMetaModel command)
		{
			_service.Execute(command);
		}

		public void CreateMetaitem(AddMetaitem command)
		{
			_service.Execute(command);
		}

        public void AddAssociationToMetaitem(CreateMetaAssociation command)
		{
			_service.Execute(command);
		}
	}
}
