using System.Linq;
using Hayman.MetaStudio.Core.Meta;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Hayman.MetaStudio.Core.Test.Domain
{
	[TestClass]
	public class ItemTests
	{
        private Model _model;

        [TestInitialize]
        public void Setup()
        {
            _model = new Model("abc");
        }

        [TestMethod]
        public void CanAddItem()
        {
            const string itemName = "itemName";

            var item = _model.AddItem(itemName);

            Assert.AreEqual(1, item.Words.Count());
            Assert.AreEqual(item.DefaultWord, item.Words.First());
            Assert.AreEqual(itemName, item.DefaultWord.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Word cannot be null or empty.", AllowDerivedTypes = false)]
        public void CannotCreateItemWithEmptyWord()
        {
            _model.AddItem(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Word cannot be null or empty.", AllowDerivedTypes = false)]
        public void CannotCreateItemWithNoWord()
        {
            _model.AddItem(null);
        }
	}
}
