using System;
using Ncqrs.Domain.Storage;
using Ncqrs.Eventing.Storage;
using Ncqrs.Eventing.ServiceModel.Bus;

namespace Hayman.Domain.Storage
{
    public class MetaModelRepository : DomainRepository
    {
        public MetaModelRepository(IEventStore store, IEventBus eventBus, ISnapshotStore snapshotStore = null, IAggregateRootCreationStrategy aggregateRootCreationStrategy = null)
		: base(new BranchableEventStoreAdapter(store), eventBus, snapshotStore, aggregateRootCreationStrategy)
		{
		}
    }
}
