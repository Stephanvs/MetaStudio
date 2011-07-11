using System;
using System.Linq;
using Hayman.Client.ReadModel.Blueprints.Meta;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hayman.Client.ReadModel.Blueprints.Test.Domain
{
	[TestClass]
	public class ModelTests
	{
        [TestMethod]
        public void CanCreateDefaultModel()
        {
            var model = new Model("TestModel");

            // Check if values are initialized
            Assert.IsNotNull(model);
            Assert.IsNotNull(model.MetaItems);
            Assert.IsNotNull(model.Items);
            Assert.IsNotNull(model.Words);

            Assert.AreEqual(0, model.MetaItems.Count());
            Assert.AreEqual(0, model.Items.Count());
            Assert.AreEqual(0, model.Words.Count());

            // Check if the value of the word actually is as expected.
            Assert.AreEqual("TestModel", model.Name);
        }

        [TestMethod]
        public void Can_Add_Two_Different_MetaItems_On_Model_And_Create_MetaAssociation_Between_Them()
        {
            // Arrange
            var model = new Model("TestModel");

            // Act
            var mi1 = model.AddMetaItem("MetaItem1");
            var mi2 = model.AddMetaItem("MetaItem2");

            model.AddMetaAssocation(mi1.Id, mi2.Id);

            //Assert
            Assert.AreEqual(1, model.MetaAssociations.Count());
            Assert.AreEqual(2, model.MetaItems.Count());

            Assert.IsTrue(model.MetaItems.Contains(mi1));
            Assert.IsTrue(model.MetaItems.Contains(mi2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Name cannot be null or empty.", AllowDerivedTypes = false)]
        public void CannotCreateModelWithoutName()
        {
            new Model(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Name cannot be null or empty.", AllowDerivedTypes = false)]
        public void CannotCreateModelWithEmptyStringAsName()
        {
            new Model(string.Empty);
        }

        [TestMethod]
        public void CanFindRelatedMetaItemsThroughMetaAssociations()
        {
            var model = new Model("abc");
            var source = model.AddMetaItem("source");
            var target = model.AddMetaItem("target");

            model.AddMetaAssocation(source.Id, target.Id);

            Assert.AreEqual(1, source.MetaAssociations.Where(a => a.TargetMetaItem.Equals(target)).Count());
        }
	}
}
