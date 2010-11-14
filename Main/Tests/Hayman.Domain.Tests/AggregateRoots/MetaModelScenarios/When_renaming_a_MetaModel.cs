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
    public class When_renaming_a_MetaModel : AggregateRootTestFixture<MetaModel>
    {
        private Guid theId = Guid.NewGuid();
        private String newName = "My old name";
        private String oldName = "My new name";

        protected override IEnumerable<SourcedEvent> Given()
        { 
            return Prepare.Events(new MetaModelCreated(theId, oldName)).ForSource(theId); 
        }

        protected override void When()
        {
            AggregateRoot.Rename(newName);
        }

        [Then]
        public void Then_there_should_be_only_one_event_be_published()
        {
            PublishedEvents.Should().HaveCount(1);
        }

        [And]
        public void And_should_be_of_type_MetaModelRenamed()
        {
            PublishedEvents.First().Should().BeOfType<MetaModelRenamed>();
        }

        [And]
        public void And_the_EventSourceId_should_be_set_to_the_MetaModelId()
        {
            var e = (MetaModelRenamed)PublishedEvents.First();
            e.EventSourceId.Should().Be(theId);
        }

        [And]
        public void And_MetaModel_newname_should_be_published_as_given_at_construct()
        {
            var e = PublishedEvents.First().As<MetaModelRenamed>();
            e.NewMetaModelName.Should().Be(newName);
        }

        [And]
        public void And_it_is_not_possible_to_rename_a_MetaModel_if_the_MetaModel_is_deleted()
        {
            AggregateRoot.Delete();
            Action action = () => When();
            action.ShouldThrow<MetaModelDeletedException>();
        }
    }
}

