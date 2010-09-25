using Ncqrs;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Eventing.ServiceModel.Bus;
using Ncqrs.Eventing.Storage;
using Ncqrs.Eventing.Storage.SQL;
using System;
using Hayman.Commands;
using Hayman.CommandExecutors;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;
using Ncqrs.Commanding.CommandExecution.Mapping.Fluent;
using Hayman.Domain;

namespace Hayman.CommandService
{
	public class Bootstrapper
	{
		public static void BootUp()
		{
			NcqrsEnvironment.SetDefault<ICommandService>(InitializeCommandService());
			NcqrsEnvironment.SetDefault<IEventStore>(InitializeEventStore());
		}

        private static ICommandService InitializeCommandService()
        {
            var service = new Ncqrs.Commanding.ServiceModel.CommandService();

            service.RegisterExecutor<CreateMetaModel>(new CreateMetaModelExecutor());
            service.RegisterExecutor<AddMetaitem>(new AddMetaitemExecutor());
            service.RegisterExecutor<AddMetaAssociation>(new AddMetaAssociationExecutor());

            Map.Command<CreateMetaModel>()
              .ToAggregateRoot<MetaModel>()
              .CreateNew(c => new MetaModel(c.MetaModelId, c.MetaModelName));
            Map.Command<AddMetaitem>()
                .ToAggregateRoot<MetaModel>()
                .WithId(c => c.MetaitemId)
                .ToCallOn((c, a) => a.AddMetaitem(c.MetaitemId, c.MetaitemName));
                
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
			return bus;
		}
	}
}