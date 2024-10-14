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
using System.Net;
using System.Runtime.InteropServices;

[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]
namespace Heos.Net
{
    public class HeosClient
    {
        public Dispatcher Dispatcher { get; }

        public Dictionary<int, HeosPlayer> Players { get; } = new Dictionary<int, HeosPlayer>();

        public Dictionary<int, HeosSource> MusicSources { get; } = new Dictionary<int, HeosSource>();

        public string SignedInUsername { get; }

        public Dictionary<int, HeosGroup> Groups { get; } = new Dictionary<int, HeosGroup>(); 

        public string ConnectionState { get => _connection.ConnectionState; }
        
        private readonly HeosConnection _connection;
        

        public HeosClient(IPAddress host)
        {
            _connection = new HeosConnection(host);
            Dispatcher = new Dispatcher();
        }
    }
}
