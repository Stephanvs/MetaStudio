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
    public class When_removing_a_metaitem_from_a_metamodel : AggregateRootTestFixture<MetaModel>
    {
        private Guid TheMetaModelId = Guid.NewGuid();
        private Guid TheMetaitemId = Guid.NewGuid();

        protected override IEnumerable<SourcedEvent> Given()
        {
            return Prepare.Events
            (
                new MetaModelCreated(TheMetaModelId, "My metamodel"),
                new MetaitemAdded(TheMetaitemId, "My metaitem", TheMetaModelId)

            ).ForSource(Guid.NewGuid());
        }

        protected override void When()
        {
            AggregateRoot.RemoveMetaitem(TheMetaitemId);
        }

        [Then]
        public void Then_only_event_event_should_be_published()
        {
            PublishedEvents.Should().HaveCount(1);
        }

        [And]
        public void And_should_be_of_type_StoryAddedToProductBacklog()
        {
            PublishedEvents.First().Should().BeOfType<MetaitemRemoved>();
        }

        [And]
        public void And_event_info_should_contain_given_details()
        {
            var e = PublishedEvents.First().As<MetaitemRemoved>();
            e.MetaitemId.Should().Be(TheMetaitemId);
        }

        [And]
        public void And_the_owner_should_be_the_metamodel_not_containing_the_metaitem()
        {
            var e = PublishedEvents.First().As<MetaitemRemoved>();
            e.MetaModelId.Should().Be(AggregateRoot.EventSourceId);
        }
    }
}
