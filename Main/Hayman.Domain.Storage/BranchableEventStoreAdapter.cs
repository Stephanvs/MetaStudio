using System;
using Ncqrs.Eventing.Storage;
using Ncqrs.Eventing.Sourcing;
using System.Collections.Generic;
using System.Linq;

namespace Hayman.Domain.Storage
{
    public class BranchableEventStoreAdapter : IEventStore
    {
        private IEventStore store;

        public BranchableEventStoreAdapter(IEventStore store)
        {
            this.store = store;
        }

        public IEnumerable<SourcedEvent> GetAllEvents(Guid id)
        {
            // Will call GetAllEventsSinceVersion
            return store.GetAllEvents(id);
        }

        public IEnumerable<SourcedEvent> GetAllEventsForBranch(Guid id, Guid branchId)
        {
            List<SourcedEvent> events = GetAllEvents(id).ToList();
            FilterEventsForBranch(events, branchId);
            return events;
        }

        public IEnumerable<SourcedEvent> GetAllEventsSinceVersion(Guid id, long version)
        {
            List<SourcedEvent> events = store.GetAllEventsSinceVersion(id, version).ToList();
            events.RemoveAll(e => e is IBranchable);
            return events;
        }

        public IEnumerable<SourcedEvent> GetAllEventsForBranchSinceVersion(Guid id, Guid branchId, long version)
        {
            List<SourcedEvent> events = GetAllEventsSinceVersion(id, version).ToList();
            FilterEventsForBranch(events, branchId);
            return events;
        }

        private static IEnumerable<SourcedEvent> FilterEventsForBranch(List<SourcedEvent> events, Guid branchId)
        {
            return events.Where(e => e is IBranchable && ((IBranchable)e).GetBranchId() == branchId);
        }

        public void Save(IEventSource source)
        {
            store.Save(source);
        }
    }
}
