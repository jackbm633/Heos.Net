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
        public Dictionary<string, List<Func<string, object[], Task>>> Signals { get; private set; } = new Dictionary<string, List<Func<string, object[], Task>>>();

        public void Connect(string signal, Func<string, object[], Task> handler)
        {
            if (!Signals.ContainsKey(signal))
            {
                Signals[signal] = new List<Func<string, object[], Task>>();
            }
            Signals[signal].Add(handler);
        }
    }
}
