using System;
using Ncqrs.Eventing.ServiceModel.Bus;
using Ncqrs.Eventing.Storage.SQL;

namespace Hayman.Domain.Storage.Tests
{
    [Specification]
    public class MsSqlStorageBaseTests : BaseTests
    {
        public MsSqlStorageBaseTests()
            : base(new MsSqlServerEventStore("Data Source=MICHEL;Initial Catalog=HaymanEventStore;Integrated Security=True"), new InProcessEventBus())
        {

        }
    }
}
