using System;
using System.Configuration;
using System.ServiceModel;
using Hayman.Service.Properties;
using Ncqrs.CommandService;
using Ncqrs.EventBus;
using Ncqrs.Eventing.ServiceModel.Bus;

namespace Hayman.Service
{
	static class Program
	{
		public static Func<IBrowsableElementStore> GetBrowsableEventStore;

		static void Main(string[] args)
		{
			GetBrowsableEventStore = GetBuiltInBrowsableElementStore;
			
			var bus = new InProcessEventBus(true);
			bus.RegisterAllHandlersInAssembly(typeof(Program).Assembly);
			var buffer = new InMemoryBufferedBrowsableElementStore(GetBrowsableEventStore(), 20 /*magic number faund in ThresholedFetchPolicy*/);
			var pipeline = new Pipeline("Default", new EventBusProcessor(bus), buffer, new ThresholdedFetchPolicy(10, 20));

			BootStrapper.BootUp(buffer);
			var commandServiceHost = new ServiceHost(typeof(CommandWebService));

			commandServiceHost.Open();
			pipeline.Start();

			Console.ReadLine();

			pipeline.Stop();
			commandServiceHost.Close();
		}

		private static IBrowsableElementStore GetBuiltInBrowsableElementStore()
		{
			var connectionString = ConfigurationManager.ConnectionStrings["EventStore"].ConnectionString;
			var browsableEventStore = new MsSqlServerEventStoreElementStore(connectionString);
			return browsableEventStore;
		}
	}
}
