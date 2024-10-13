/*
 * Heos.NET
 * Copyright (C) 2024 Jack Beckitt-Marshall
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Net;

namespace Heos.Net.Tests
{
    [TestClass]
    public class HeosTests
    {
        /// <summary>
        /// Checks initialising the HEOS client sets properties correctly.
        /// </summary>
        [TestMethod]
        public void Heos_Init()
        {
            // Act
            var heos = new HeosClient(IPAddress.Parse("127.0.0.1"));

            // Assert
            Assert.IsInstanceOfType<Dispatcher>(heos.Dispatcher);
            Assert.AreEqual(0, heos.Players.Count);
            Assert.AreEqual(0, heos.MusicSources.Count);
            Assert.AreEqual(Constants.StateDisconnected, heos.ConnectionState);
        }
    }
}
