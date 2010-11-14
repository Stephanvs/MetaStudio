using System;
using System.Linq;
using Ncqrs.Spec;
using Hayman.Events;
using FluentAssertions;
using Hayman.Domain;

namespace DomainTests.AggregateRoots.MetaModelScenarios
{
    [Specification]
    public class When_creating_a_MetaModel : AggregateRootTestFixture<MetaModel>
    {
        private Guid theId = Guid.NewGuid();
        private String theName = "My MetaModel";

        protected override void When()
        {
            AggregateRoot = new MetaModel(theId, theName);
        }

        [Then]
        public void Then_there_should_be_only_one_event_be_published()
        {
            PublishedEvents.Should().HaveCount(1);
        }

        [And]
        public void And_should_be_of_type_MetaModelCreated()
        {
            PublishedEvents.First().Should().BeOfType<MetaModelCreated>();
        }

        [And]
        public void And_the_EventSourceId_should_be_set_to_the_MetaModelId()
        {
            var e = (MetaModelCreated)PublishedEvents.First();
            AggregateRoot.EventSourceId.Should().Be(e.MetaModelId);
        }

        [And]
        public void And_MetaModel_id_and_name_should_be_published_as_given_at_construct()
        {
            var e = PublishedEvents.First().As<MetaModelCreated>();
            e.MetaModelId.Should().Be(theId);
            e.MetaModelName.Should().Be(theName);
        }
    }
}

