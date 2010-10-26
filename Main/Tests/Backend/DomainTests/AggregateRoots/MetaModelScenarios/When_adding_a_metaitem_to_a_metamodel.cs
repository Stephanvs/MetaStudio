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
    public class When_adding_a_MetaItem_to_a_MetaModel : AggregateRootTestFixture<MetaModel>
    {
        private Guid theMetaModelId = Guid.NewGuid();
        private Guid theMetaItemId = Guid.NewGuid();
        private string theMetaItemName = "MetaItem";

        protected override IEnumerable<SourcedEvent> Given()
        {
            return Prepare.Events
            (
                new MetaModelCreated(theMetaModelId, "My metamodel")
            ).ForSource(theMetaModelId);
        }

        protected override void When()
        {
            AggregateRoot.AddMetaItem(theMetaItemId, theMetaItemName);
        }

        [Then]
        public void Then_there_should_be_one_event_be_published()
        {
            PublishedEvents.Should().HaveCount(1);
        }

        [And]
        public void And_should_be_of_type_MetaItemAdded()
        {
            PublishedEvents.First().Should().BeOfType<MetaItemAdded>();
        }

        [And]
        public void And_the_MetaItem_id_and_name_should_be_published_as_given_at_construct()
        {
            var e = PublishedEvents.First().As<MetaItemAdded>();
            e.MetaItemId.Should().Be(theMetaItemId);
            e.MetaItemName.Should().Be(theMetaItemName);
        }

        [And]
        public void And_the_owner_should_be_the_MetaModel_containing_the_MetaItem()
        {
            var e = PublishedEvents.First().As<MetaItemAdded>();
            e.MetaModelId.Should().Be(AggregateRoot.EventSourceId);
            AggregateRoot.ContainsMetaItem(e.MetaItemId).Should().BeTrue();
        }
    }
}
