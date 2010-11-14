﻿using System;
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
    public class When_removing_a_MetaItem_from_a_MetaModel : AggregateRootTestFixture<MetaModel>
    {
        private Guid theMetaModelId = Guid.NewGuid();
        private Guid theMetaItemId = Guid.NewGuid();

        protected override IEnumerable<SourcedEvent> Given()
        {
            return Prepare.Events
            (
                new MetaModelCreated(theMetaModelId, "My metamodel"),
                new MetaItemAdded(theMetaItemId, "My MetaItem")

            ).ForSource(theMetaModelId);
        }

        protected override void When()
        {
            AggregateRoot.RemoveMetaItem(theMetaItemId);
        }

        [Then]
        public void Then_there_should_be_one_event_be_published()
        {
            PublishedEvents.Should().HaveCount(1);
        }

        [And]
        public void And_should_be_of_type_MetaItemRemoved()
        {
            PublishedEvents.First().Should().BeOfType<MetaItemRemoved>();
        }

        [And]
        public void And_MetaModel_id_should_be_published_as_given_at_construct()
        {
            var e = PublishedEvents.First().As<MetaItemRemoved>();
            e.MetaItemId.Should().Be(theMetaItemId);
        }

        [And]
        public void And_the_owner_should_be_the_MetaModel_not_containing_the_MetaItem()
        {
            var e = PublishedEvents.First().As<MetaItemRemoved>();
            //e.MetaModelId.Should().Be(AggregateRoot.EventSourceId);
            AggregateRoot.ContainsMetaItem(e.MetaItemId).Should().BeFalse();
        }
    }
}