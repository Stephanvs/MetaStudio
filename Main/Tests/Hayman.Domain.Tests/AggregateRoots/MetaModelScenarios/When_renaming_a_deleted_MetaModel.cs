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
    public class When_renaming_a_deleted_MetaModel : AggregateRootTestFixture<MetaModel>
    {
        private Guid theId = Guid.NewGuid();
        private String newName = "My old name";
        private String oldName = "My new name";
        private Action renameMetaModel;

        protected override IEnumerable<SourcedEvent> Given()
        { 
            return Prepare.Events(
                new MetaModelCreated(theId, oldName),
                new MetaModelDeleted(theId)
            ).ForSource(theId); 
        }

        protected override void When()
        {
            renameMetaModel = () => AggregateRoot.Rename(newName);
            renameMetaModel.Invoke();
        }

        [Then]
        public void Then_there_should_be_a_MetaModelDeletedException()
        {
            renameMetaModel.ShouldThrow<MetaModelDeletedException>();
        }

        [And]
        public void And_there_should_be_only_no_event_be_published()
        {
            PublishedEvents.Should().HaveCount(0);
        }
    }
}

