using System;
using Ncqrs.Spec;
using System.Collections.Generic;
using Ncqrs.Eventing.Sourcing;
using Ncqrs.Domain;
using Hayman.Events;
using Hayman.Domain;
using FluentAssertions;
using System.Linq;

namespace DomainTests.AggregateRoots.MetaModelScenarios
{
    [Specification]
    public class When_removing_a_MetaItem_from_a_deleted_MetaModel : AggregateRootTestFixture<MetaModel>
    {
        private Guid theMetaModelId = Guid.NewGuid();
        private Guid theMetaItemId = Guid.NewGuid();
        private Action removeMetaItem;

        protected override IEnumerable<SourcedEvent> Given()
        {
            return Prepare.Events
            (
                new MetaModelCreated(theMetaModelId, "My metamodel"),
                new MetaItemAdded(theMetaItemId, "My MetaItem", theMetaModelId),
                new MetaModelDeleted(theMetaModelId)

            ).ForSource(theMetaModelId);
        }

        protected override void When()
        {
            removeMetaItem = () => AggregateRoot.RemoveMetaItem(theMetaItemId);
            removeMetaItem.Invoke();
        }

        [Then]
        public void Then_there_should_be_a_MetaModelDeletedException()
        {
            removeMetaItem.ShouldThrow<MetaModelDeletedException>();
        }

        [And]
        public void And_there_should_be_no_event_be_published()
        {
            PublishedEvents.Should().HaveCount(0);
        }
    }
}
