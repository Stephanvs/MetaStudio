using System.Configuration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Hayman.Commands.Models;
using Ncqrs;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.CommandService.Infrastructure;
using Ncqrs.Config.Windsor;
using Ncqrs.EventBus;
using Ncqrs.Eventing.ServiceModel.Bus;
using Ncqrs.Eventing.Sourcing.Snapshotting;
using Ncqrs.Eventing.Storage;
using Ncqrs.Eventing.Storage.RavenDB;
using Ncqrs.Eventing.Storage.SQL;

namespace Hayman.Service
{
    public static class BootStrapper
    {
        public static void BootUp(InMemoryBufferedBrowsableElementStore buffer)
        {
			var connectionString = ConfigurationManager.ConnectionStrings["EventStore"].ConnectionString;
        	//var dsa = new InMemoryEventStore();
        	var dsa = new RavenDBEventStore("http://localhost:8080/");

			//Assembly asm = Assembly.LoadFrom("Domain.dll");
			IWindsorContainer container = new WindsorContainer();
			//container.AddFacility("ncqrs.ds", new DynamicSnapshotFacility(asm));
			container.Register(
				Component.For<ISnapshottingPolicy>().ImplementedBy<SimpleSnapshottingPolicy>(),
				Component.For<ICommandService>().Instance(InitializeCommandService()),
				Component.For<IEventBus>().Instance(InitializeEventBus(buffer)),
				Component.For<IEventStore>() /*.Forward<ISnapshotStore>() */.Instance(dsa),
				Component.For<IKnownCommandsEnumerator>().Instance(new AllCommandsInAppDomainEnumerator())//,
				//Component.For<Model>().AsSnapshotable()
				);

        	NcqrsEnvironment.Configure(new WindsorConfiguration(container));
        }

        private static ICommandService InitializeCommandService()
        {
            var commandAssembly = typeof(CreateModel).Assembly;

            var service = new CommandService();
            service.RegisterExecutorsInAssembly(commandAssembly);
            service.AddInterceptor(new ThrowOnExceptionInterceptor());

            return service;
        }

        private static IEventBus InitializeEventBus(InMemoryBufferedBrowsableElementStore buffer)
        {
            var bus = new InProcessEventBus();

            bus.RegisterHandler(new InMemoryBufferedEventHandler(buffer));

            return bus;
        }
    }
}