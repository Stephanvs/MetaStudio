using System;
using System.ServiceModel;
using Hayman.Service.Properties;
using Ncqrs.CommandService;
using Ncqrs.EventBus;
using Ncqrs.Eventing.ServiceModel.Bus;
using Hayman.ReadModel.Denormalizers;

namespace Hayman.Service
{
    static class Program
    {
        static void Main(string[] args)
        {
            var bus = new InProcessEventBus(true);
            bus.RegisterAllHandlersInAssembly(typeof(MetaModelDenormalizer).Assembly);

            var browsableEventStore = new MsSqlServerEventStoreElementStore(Settings.Default.EventStoreConnectionString);
            var buffer = new InMemoryBufferedBrowsableElementStore(browsableEventStore, 20 /*magic number faund in ThresholedFetchPolicy*/);
            var pipeline = new Pipeline("Default", new EventBusProcessor(bus), buffer, new ThresholdedFetchPolicy(10, 20));

            //var pipeline = Pipeline.Create("Default", new EventBusProcessor(bus), buffer);

            BootStrapper.BootUp(buffer);
            var commandServiceHost = new ServiceHost(typeof(CommandWebService));

            commandServiceHost.Open();
            pipeline.Start();

            Console.ReadLine();

            pipeline.Stop();
            commandServiceHost.Close();
        }
    }
}
