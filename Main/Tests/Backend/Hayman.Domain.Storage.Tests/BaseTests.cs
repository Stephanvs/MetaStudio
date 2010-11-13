using System;
using FluentAssertions;
using Ncqrs.Eventing.Storage;
using Ncqrs.Eventing.ServiceModel.Bus;

namespace Hayman.Domain.Storage.Tests
{
    [Specification]
    public abstract class BaseTests : BaseTestFixture
    {
        private IEventStore store;
        private IEventBus bus;
        private MetaModelRepository repository;
        private Guid metaModelId = Guid.NewGuid();

        protected BaseTests(IEventStore store, IEventBus bus)
        {
            this.store = store;
            this.bus = bus;
        }

        protected override void Given()
        {
            repository = new MetaModelRepository(store, bus);
        }

        protected override void When()
        {
            var metaModel = new MetaModel(metaModelId, "Foo");
            repository.Save(metaModel);
        }

        [Then]
        public void Todo()
        {
            repository.GetById<MetaModel>(metaModelId).EventSourceId.Should().Be(metaModelId);
        }


        //[TestMethod]
        //public void TestMethod1()
        //{
        //    //var store = new InMemoryEventStore();
        //    //var bus = new InProcessEventBus();
        //    //var repository = new MetaModelRepository(store, bus);
        //    //var metaModelId = Guid.NewGuid();
        //    var metaModel = new MetaModel(metaModelId, "Foo");
        //    repository.Save(metaModel);
        //    repository.GetById<MetaModel>(metaModelId).EventSourceId.Should().Be(metaModelId);
        //}

        //[TestMethod]
        //public void TestMethod2()
        //{
        //    var store = new InMemoryEventStore();
        //    var bus = new InProcessEventBus();
        //    var repository = new MetaModelRepository(store, bus);
        //    var metaModelId = Guid.NewGuid();
        //    var metaModel = new MetaModel(metaModelId, "Foo");
        //    var metaItemId = Guid.NewGuid();
        //    metaModel.AddMetaItem(metaItemId, "Bar");
        //    repository.Save(metaModel);
        //    repository.GetById<MetaModel>(metaModelId).EventSourceId.Should().Be(metaModelId);
        //    repository.GetById<MetaModel>(metaModelId).ContainsMetaItem(metaItemId).Should().BeTrue();
        //}
    }
}
