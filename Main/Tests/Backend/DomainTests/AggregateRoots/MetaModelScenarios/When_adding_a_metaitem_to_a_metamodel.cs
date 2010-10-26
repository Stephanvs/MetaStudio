﻿using System;
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
        public void Then_there_should_be_one_event_be_published()
        {
            PublishedEvents.Should().HaveCount(1);
        }

        [And]
        public void And_should_be_of_type_MetaitemAdded()
        {
            PublishedEvents.First().Should().BeOfType<MetaitemAdded>();
        }

        [And]
        public void And__the_metaitem_id_and_name_should_be_published_as_given_at_construct()
        {
            var e = PublishedEvents.First().As<MetaitemAdded>();
            e.MetaitemId.Should().Be(TheMetaitemId);
            e.MetaitemName.Should().Be(TheMetaitemName);
        }

        [And]
        public void And_the_owner_should_be_the_metamodel_containing_the_metaitem()
        {
            var e = PublishedEvents.First().As<MetaitemAdded>();
            e.MetaModelId.Should().Be(AggregateRoot.EventSourceId);
            AggregateRoot.ContainsMetaitem(e.MetaitemId).Should().BeTrue();
        }
    }
}
