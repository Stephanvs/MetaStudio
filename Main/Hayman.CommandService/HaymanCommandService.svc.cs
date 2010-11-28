using System;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Commanding;

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

        public void ExecuteCommand(ICommand command)
        {
            _service.Execute(command);
        }
    }
}
