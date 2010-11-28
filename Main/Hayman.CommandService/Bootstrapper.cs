using Ncqrs;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Eventing.ServiceModel.Bus;
using Ncqrs.Eventing.Storage;
using Ncqrs.Eventing.Storage.SQL;
using System;
using Hayman.Domain.Storage;
using Hayman.ReadModel.Denormalizers;
using Hayman.Commands;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Hayman.CommandService
{
	public class Bootstrapper
	{
		public static void BootUp()
		{
			NcqrsEnvironment.SetDefault<ICommandService>(InitializeCommandService());
            NcqrsEnvironment.SetDefault<IEventBus>(InitializeEventBus());
			NcqrsEnvironment.SetDefault<IEventStore>(InitializeEventStore());
		}

		private static ICommandService InitializeCommandService()
		{
            var service = new Ncqrs.Commanding.ServiceModel.CommandService();
            service.RegisterExecutorsInAssembly(typeof(CreateMetaModel).Assembly);
            return service;
		}

		private static IEventStore InitializeEventStore()
		{
            var store = new BranchableEventStoreAdapter(new MsSqlServerEventStore(@"Data Source=MICHEL;Initial Catalog=HaymanEventStore;Integrated Security=True;MultipleActiveResultSets=True"));
			return store;
		}

		private static IEventBus InitializeEventBus()
		{
			var bus = new InProcessEventBus();
			bus.RegisterAllHandlersInAssembly(typeof(MetaModelDenormalizer).Assembly);
			return bus;
		}
	}
}