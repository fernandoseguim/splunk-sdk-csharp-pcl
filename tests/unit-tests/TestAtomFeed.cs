﻿/*
 * Copyright 2014 Splunk, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License"): you may
 * not use this file except in compliance with the License. You may obtain
 * a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations
 * under the License.
 */

namespace Splunk.Sdk
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestAtomFeed
    {
        [TestMethod]
        public void Construct()
        {
            string documentPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "data", "AtomFeed.xml"));
            Assert.IsTrue(File.Exists(documentPath));
            feed = new AtomFeed<Entity>(new Context(Protocol.Https, "localhost", 8089), ResourceName.Jobs, XDocument.Load(documentPath));
        }

        [TestMethod]
        public void Access()
        {
            var expected = new List<string>() { "https://localhost:8089/servicesNS/admin/search/search/jobs/1392687998.313"	};
            List<string> actual;
            
            actual = new List<string>();

            foreach (var entity in feed.Entities)
            {
                actual.Add(entity.ToString());
            }

            CollectionAssert.AreEqual(expected, actual);

            actual = new List<string>();

            for (int i = 0; i < feed.Entities.Count; i++)
            {
                actual.Add(feed.Entities[i].ToString());
            }

            CollectionAssert.AreEqual(expected, actual);
        }

        #region Privates

        static AtomFeed<Entity> feed;

        #endregion
    }
}