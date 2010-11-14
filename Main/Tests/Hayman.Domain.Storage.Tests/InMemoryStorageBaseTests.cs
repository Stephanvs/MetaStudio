using System;
using Ncqrs.Eventing.Storage;
using Ncqrs.Eventing.ServiceModel.Bus;

namespace Hayman.Domain.Storage.Tests
{
    [Specification]
    public class InMemoryStorageBaseTests : BaseTests
    {
        public InMemoryStorageBaseTests()
            : base(new InMemoryEventStore(), new InProcessEventBus())
        {
            
        }

    }
}
