using Ncqrs;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Eventing.ServiceModel.Bus;
using Ncqrs.Eventing.Storage;
using Ncqrs.Eventing.Storage.SQL;
using System;
using Hayman.Commands;
//using Hayman.CommandExecutors;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Hayman.CommandService
{
	public class Bootstrapper
	{
		public static void BootUp()
		{
			//var config = new StructureMapConfiguration(cfg =>
			//{
			//	cfg.For<ICommandService>().Use(InitializeCommandService);
			//	cfg.For<IEventBus>().Use(InitializeEventBus);
			//	cfg.For<IEventStore>().Use(InitializeEventStore);
			//});

			//NcqrsEnvironment.Configure(config);

			NcqrsEnvironment.SetDefault<ICommandService>(InitializeCommandService());
			NcqrsEnvironment.SetDefault<IEventStore>(InitializeEventStore());
		}

		private static ICommandService InitializeCommandService()
		{
			var service = new Ncqrs.Commanding.ServiceModel.CommandService();
            //service.RegisterExecutor(new AttributeMappedCommandExecutor<CreateModelCommand>());
            //service.RegisterExecutor(new AttributeMappedCommandExecutor<CreateModelCommand>());
            //service.RegisterExecutor(new AttributeMappedCommandExecutor<CreateModelCommand>());

            //service.RegisterExecutor<CreateMetaModelCommand>(new CreateMetaModelCommandExecutor());
            //service.RegisterExecutor<CreateMetaItemCommand>(new CreateMetaItemCommandExecutor());
            //service.RegisterExecutor<AddMetaItemToModelCommand>(new AddMetaItemToModelCommandExecutor());
            //service.RegisterExecutor<AddMetaAssociationCommand>(new AddMetaAssociationCommandExecutor());
			//TODO: service.RegisterExecutorForAllMappedCommandsInAssembly(typeof(CreateNewNote).Assembly);

			return service;
		}

		private static IEventStore InitializeEventStore()
		{
			var store = new MsSqlServerEventStore(@"Data Source=.\sqlexpress;Initial Catalog=HaymanEventStore;Integrated Security=True");
			return store;
		}

		private static IEventBus InitializeEventBus()
		{
			var bus = new InProcessEventBus();
			//bus.RegisterAllHandlersInAssembly(typeof(NoteItemDenormalizer).Assembly);

			return bus;
		}
	}
}