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

namespace Heos.Net.Tests
{
    [TestClass]
    public class DispatcherTests
    {
        /// <summary>
        /// Tests the connect function.
        /// </summary>
        [TestMethod]
        public void Test_Connect()
        {
            // Arrange
            var dispatcher = new Dispatcher();

            static Task Handler(string _, params object[] args)
            {
                return Task.CompletedTask;
            }
            // Act
            dispatcher.Connect("TEST", Handler);

            // Assert
            Assert.IsTrue(dispatcher.Signals["TEST"].Contains(Handler));
        }

        /// <summary>
        /// Tests the disconnect function.
        /// </summary>
        [TestMethod]
        public void Test_Disconnect()
        {
            // Arrange
            var dispatcher = new Dispatcher();

            static Task Handler(string _, params object[] args)
            {
                return Task.CompletedTask;
            }
            var disconnect = dispatcher.Connect("TEST", Handler);
            // Act
            disconnect();

            // Assert
            Assert.IsFalse(dispatcher.Signals["TEST"].Contains(Handler));
        }

        /// <summary>
        /// Tests the disconnect all function.
        /// </summary>
        [TestMethod]
        public void Test_DisconnectAll()
        {
            // Arrange
            var dispatcher = new Dispatcher();

            static Task Handler(string _, params object[] args)
            {
                return Task.CompletedTask;
            }
            dispatcher.Connect("TEST", Handler);
            dispatcher.Connect("TEST", Handler);
            dispatcher.Connect("TEST2", Handler);
            dispatcher.Connect("TEST3", Handler);

            // Act
            dispatcher.DisconnectAll();

            // Assert
            Assert.IsFalse(dispatcher.Signals["TEST"].Contains(Handler));
            Assert.IsFalse(dispatcher.Signals["TEST2"].Contains(Handler));
            Assert.IsFalse(dispatcher.Signals["TEST3"].Contains(Handler));

        }

    }
}
