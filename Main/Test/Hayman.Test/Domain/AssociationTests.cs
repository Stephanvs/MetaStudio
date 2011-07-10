using System.Linq;
using Hayman.MetaStudio.Core.Graph;
using Hayman.MetaStudio.Core.Meta;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Hayman.MetaStudio.Core.Test.Domain
{
	[TestClass]
	public class AssociationTests
	{
        private Model _model;

        [TestInitialize]
        public void Setup()
        {
            _model = new Model("abc");
        }

        [TestMethod]
        public void AfterCreatingAnAssociationTheItemAlsoHasTheAssociation()
        {
            // Arrange
            var item1 = _model.AddItem("item1");
            var item2 = _model.AddItem("item2");

            // Act
            var assocation = _model.AddAssociation(item1.Id, item2.Id);

            // Assert
            Assert.AreEqual(item1, assocation.SourceItem);
            Assert.AreEqual(item2, assocation.TargetItem);

            Assert.IsTrue(item1.Associations.Contains(assocation), "Item is expected to have a reference to the Association");

            // Todo: is this the correct behaviour? As in: Does Item.Associations contain both incoming and outgoing Associations?
            Assert.IsFalse(item2.Associations.Contains(assocation), "Item is not expected to have a reference to the Association");
        }

        //[TestMethod]
        //public void MetaAssociation_Is_Directed()
        //{
        //    var mi1 = new MetaItem("mi1");
        //    var mi2 = new MetaItem("mi2");

        //    var a = new MetaAssociation(mi1, mi2);
        //    var b = new MetaAssociation(mi2, mi1);

        //    Assert.AreNotEqual(a, b);
        //}

        //[TestMethod]
        //public void MetaAssociation_Equality()
        //{
        //    var mi1 = new MetaItem("mi1");
        //    var mi2 = new MetaItem("mi2");

        //    var a = new MetaAssociation(mi1, mi2);
        //    var b = new MetaAssociation(mi1, mi2);

        //    Assert.AreEqual(a, b);
        //}

        //[TestMethod]
        //public void Association_Equality()
        //{
        //    var i1 = new Item("item1");
        //    var i2 = new Item("item2");

        //    var a = new Association(i1, i2);
        //    var b = new Association(i1, i2);

        //    Assert.AreEqual(a, b);
        //}

        //[TestMethod]
        //public void InstanceAssociation_Equality()
        //{
        //    var metaitem = new MetaItem("metaitem");
        //    var item = new Item("item");

        //    var a = new InstanceAssociation(metaitem, item);
        //    var b = new InstanceAssociation(metaitem, item);

        //    Assert.AreEqual(a, b);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(InvalidOperationException), "Cannot create MetaAssociation with the same source and target MetaItem", AllowDerivedTypes = false)]
        //public void Cannot_Create_MetaAssociation_With_Itself()
        //{
        //    var m1 = new MetaItem("mi1");
        //    var a = new MetaAssociation(m1, m1);
        //}

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Cannot add the same Association to a Model twice.", AllowDerivedTypes = false)]
        public void CannotAddSameAssociationTwice()
        {
            var item1 = _model.AddItem("Item1");
            var item2 = _model.AddItem("Item2");

            _model.AddAssociation(item1.Id, item2.Id);
            _model.AddAssociation(item1.Id, item2.Id);
        }
	}
}
