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

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Heos.Net
{
    public class Dispatcher
    {
        private readonly Func<string, Func<string, object[], Task>, Action> _connect;
        private readonly string _signalPrefix = string.Empty;
        private readonly List<Action> _disconnects = new List<Action>();

        public Dispatcher()
        {
            _connect = DefaultConnect;
        }

        /// <summary>
        /// Dictionary of registered signals and callbacks.
        /// </summary>
        public Dictionary<string, List<Func<string, object[], Task>>> Signals { get; private set; } = new Dictionary<string, List<Func<string, object[], Task>>>();

        /// <summary>
        /// Connects a function to a signal.
        /// </summary>
        /// <param name="signal">Signal to connect to the handler.</param>
        /// <param name="handler">Handler which handles the signal</param>
        /// <returns>Action, which is used to disconnect.</returns>
        public Action Connect(string signal, Func<string, object[], Task> handler)
        {
            var disconnect = _connect(_signalPrefix + signal, handler);
            _disconnects.Add(disconnect);
            return disconnect;
        }

        /// <summary>
        /// Connects a function to a signal.
        /// </summary>
        /// <param name="signal">Signal to connect to the handler.</param>
        /// <param name="handler">Handler which handles the signal</param>
        /// <returns>Action, which is used to disconnect.</returns>
        public Action DefaultConnect(string signal, Func<string, object[], Task> handler)
        {
            if (!Signals.ContainsKey(signal))
            {
                Signals[signal] = new List<Func<string, object[], Task>>();
            }
            Signals[signal].Add(handler);

            void RemoveDispatcher()
            {
                if (Signals[signal].Contains(handler))
                {
                    Signals[signal].Remove(handler);
                }
            }

            return RemoveDispatcher;

        }

        /// <summary>
        /// Disconnects all connected signals.
        /// </summary>
        public void DisconnectAll()
        {
            foreach (var action in _disconnects)
            {
                action();
            }
        }
    }
}
