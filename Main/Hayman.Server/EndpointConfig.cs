using System;
using NServiceBus;

namespace Hayman.Server
{
	public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher, IWantCustomInitialization
	{
		public void Init()
		{
			Configure.With()
			   .DefaultBuilder()
			   .BinarySerializer()
			   .InstallNcqrs()
			   .MsmqTransport()
			   .PurgeOnStartup(true);
		}
	}
}
