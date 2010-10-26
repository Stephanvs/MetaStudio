using System;
using System.Linq;
using Ncqrs.Spec;
using Hayman.Events;
using FluentAssertions;
using Hayman.Domain;
using System.Collections.Generic;
using Ncqrs.Eventing.Sourcing;

namespace DomainTests.AggregateRoots.MetaModelScenarios
{
    [Specification]
    public class When_deleting_a_MetaModel : AggregateRootTestFixture<MetaModel>
    {
        private Guid theId = Guid.NewGuid();
        private String theName = "My MetaModel";

        protected override IEnumerable<SourcedEvent> Given()
        {
            return Prepare.Events
            (
                new MetaModelCreated(theId, theName)
            ).ForSource(theId);
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
        public void And_should_be_of_type_MetaModelDeleted()
        {
            PublishedEvents.First().Should().BeOfType<MetaModelDeleted>();
        }

        [And]
        public void And_the_EventSourceId_should_be_set_to_the_MetaModelId()
        {
            var e = (MetaModelDeleted)PublishedEvents.First();
            AggregateRoot.EventSourceId.Should().Be(e.MetaModelId);
        }
    }
}

