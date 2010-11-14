using System;
using Ncqrs.Spec;
using System.Collections.Generic;
using Ncqrs.Eventing.Sourcing;
using Hayman.Events;
using Hayman.Domain;
using FluentAssertions;
using System.Linq;

namespace DomainTests.AggregateRoots.MetaModelScenarios
{
    [Specification]
    public class When_adding_a_MetaItem_to_a_deleted_MetaModel : AggregateRootTestFixture<MetaModel>
    {
        private Guid theMetaModelId = Guid.NewGuid();
        private Guid theMetaItemId = Guid.NewGuid();
        private string theMetaItemName = "MetaItem";
        private Action addMetaItem;

        protected override IEnumerable<SourcedEvent> Given()
        {
            return Prepare.Events
            (
                new MetaModelCreated(theMetaModelId, "My metamodel"),
                new MetaModelDeleted(theMetaModelId)

            ).ForSource(theMetaModelId);
        }

        protected override void When()
        {
            addMetaItem = () => AggregateRoot.AddMetaItem(theMetaItemId, theMetaItemName);
            addMetaItem.Invoke();
        }

        [Then]
        public void Then_there_should_be_a_MetaModelDeletedException()
        {
            addMetaItem.ShouldThrow<MetaModelDeletedException>();
        }

        [Then]
        public void And_there_should_be_no_event_be_published()
        {
            PublishedEvents.Should().HaveCount(0);
        }
    }
}
