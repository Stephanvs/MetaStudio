using System;
using NServiceBus;

namespace Hayman.Shell
{
	public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
	{
		public void Init()
		{
			Configure.With()
			   .DefaultBuilder()
			   .BinarySerializer();
		}
	}
}
