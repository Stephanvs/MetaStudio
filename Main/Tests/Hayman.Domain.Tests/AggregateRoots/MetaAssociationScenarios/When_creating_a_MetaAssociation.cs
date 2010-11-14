using System;
using System.Linq;
using Ncqrs.Spec;
using Hayman.Events;
using FluentAssertions;
using Hayman.Domain;

namespace DomainTests.AggregateRoots.MetaAssociationScenarios
{
    [Specification]
    public class When_creating_a_MetaAssociation : AggregateRootTestFixture<MetaAssociation>
    {
        private Guid theId = Guid.NewGuid();
        private Guid theSourceId = Guid.NewGuid();
        private Guid theTargetId = Guid.NewGuid();

        protected override void When()
        {
            AggregateRoot = new MetaAssociation(theId, theSourceId, theTargetId);
        }

        [Then]
        public void Then_there_should_be_only_one_event_be_published()
        {
            PublishedEvents.Should().HaveCount(1);
        }

        [And]
        public void And_should_be_of_type_MetaAssociationCreated()
        {
            PublishedEvents.First().Should().BeOfType<MetaAssociationCreated>();
        }

        [And]
        public void And_the_EventSourceId_should_be_set_to_the_MetaAssociationId()
        {
            var e = (MetaAssociationCreated)PublishedEvents.First();
            AggregateRoot.EventSourceId.Should().Be(e.MetaAssociationId);
        }

        [And]
        public void And_MetaAssociation_id_source_and_target_should_be_published_as_given_at_construct()
        {
            var e = PublishedEvents.First().As<MetaAssociationCreated>();
            e.MetaAssociationId.Should().Be(theId);
            e.MetaItemSourceId.Should().Be(theSourceId);
            e.MetaItemTargetId.Should().Be(theTargetId);
        }
    }
}

