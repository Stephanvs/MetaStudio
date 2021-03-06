﻿using System.Linq;
using Hayman.Client.ReadModel.Blueprints.Meta;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Hayman.MetaStudio.Core.Test.Client.ReadModels.Blueprints
{
	[TestClass]
	public class MetaItemTests
	{
        private Model _model;

        [TestInitialize]
        public void Setup()
        {
            _model = new Model("abc");
        }

        [TestMethod]
        public void CanAddMetaItem()
        {
            const string metaItemName = "MetaItemName";

            var metaItem = _model.AddMetaItem(metaItemName);

            Assert.AreEqual(1, metaItem.Words.Count());
            Assert.AreEqual(metaItem.DefaultWord, metaItem.Words.First());
            Assert.AreEqual(metaItemName, metaItem.DefaultWord.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Word cannot be null or empty.", AllowDerivedTypes = false)]
        public void CannotCreateMetaItemWithEmptyWord()
        {
            _model.AddMetaItem(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Word cannot be null or empty.", AllowDerivedTypes = false)]
        public void CannotCreateMetaItemWithNoWord()
        {
            _model.AddMetaItem(null);
        }

       
    }
}
