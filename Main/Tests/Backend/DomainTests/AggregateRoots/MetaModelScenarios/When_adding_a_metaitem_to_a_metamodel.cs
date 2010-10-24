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
    public class When_adding_a_metaitem_to_a_metamodel : AggregateRootTestFixture<MetaModel>
    {
        private Guid TheMetaitemId = Guid.NewGuid();
        private string TheMetaitemName = "metaitem";

        protected override IEnumerable<SourcedEvent> Given()
        {
            return Prepare.Events
            (
                new MetaModelCreated(Guid.NewGuid(), "My metamodel")
            ).ForSource(Guid.NewGuid());
        }

        protected override void When()
        {
            AggregateRoot.AddMetaitem(TheMetaitemId, TheMetaitemName);
        }

        [Then]
        public void Then_only_event_event_should_be_published()
        {
            PublishedEvents.Should().HaveCount(1);
        }

        [And]
        public void And_should_be_of_type_StoryAddedToProductBacklog()
        {
            PublishedEvents.First().Should().BeOfType<MetaAssociationCreated>();
        }

        [And]
        public void And_event_info_should_contain_given_details()
        {
            var e = PublishedEvents.First().As<MetaAssociationCreated>();
            e.MetaitemId.Should().Be(TheMetaitemId);
            e.MetaitemName.Should().Be(TheMetaitemName);
        }

        [And]
        public void And_the_owner_should_be_the_metamodel_containing_the_metamitem()
        {
            var e = PublishedEvents.First().As<MetaAssociationCreated>();
            e.MetaModelId.Should().Be(AggregateRoot.EventSourceId);
            AggregateRoot.ContainsMetaitem(e.MetaitemId).Should().BeTrue();
        }
    }
}
