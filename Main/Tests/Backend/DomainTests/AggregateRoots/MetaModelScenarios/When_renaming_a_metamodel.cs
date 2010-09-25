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
    public class When_renaming_a_metamodel : AggregateRootTestFixture<MetaModel>
    {
        private Guid TheId = Guid.NewGuid();
        private String newName = "My old name";
        private String oldName = "My new name";

        protected override IEnumerable<SourcedEvent> Given()
        { 
            return Prepare.Events(new MetaModelCreated(TheId, oldName)).ForSource(TheId); 
        }

        protected override void When()
        {
            AggregateRoot.Rename(newName);
        }

        [Then]
        public void Then_the_ProjectRenamed_event_been_published() {
            PublishedEvents.Count().Should().Be(1); 
            var evnt = (MetaModelRenamed)PublishedEvents.First(); 
            evnt.EventSourceId.Should().Be(TheId);
            evnt.NewMetaModelName.Should().Be(newName);
        }
    }
}

