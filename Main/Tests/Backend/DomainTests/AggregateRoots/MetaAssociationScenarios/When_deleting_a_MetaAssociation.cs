using System;
using System.Linq;
using Ncqrs.Spec;
using Hayman.Events;
using FluentAssertions;
using Hayman.Domain;
using System.Collections.Generic;
using Ncqrs.Eventing.Sourcing;

namespace DomainTests.AggregateRoots.MetaAssociationScenarios
{
    [Specification]
    public class When_deleting_a_MetaAssociation : AggregateRootTestFixture<MetaAssociation>
    {
        private Guid theId = Guid.NewGuid();
        private Guid theSourceId = Guid.NewGuid();
        private Guid theTargetId = Guid.NewGuid();

        protected override IEnumerable<SourcedEvent> Given()
        {
            return Prepare.Events
            (
                new MetaAssociationCreated(theId, theSourceId, theTargetId)
            ).ForSource(Guid.NewGuid());
        }

        protected override void When()
        {
            AggregateRoot.Delete();
        }

        [Then]
        public void Then_there_should_be_only_one_event_be_published()
        {
            PublishedEvents.Should().HaveCount(1);
        }

        [And]
        public void And_should_be_of_type_MetaAssociationDeleted()
        {
            PublishedEvents.First().Should().BeOfType<MetaAssociationDeleted>();
        }

        [And]
        public void And_the_EventSourceId_should_be_set_to_the_MetaAssociationId()
        {
            var e = (MetaAssociationDeleted)PublishedEvents.First();
            AggregateRoot.EventSourceId.Should().Be(e.MetaAssociationId);
        }

        // Any operation on MetaAssociation should fail
    }
}

