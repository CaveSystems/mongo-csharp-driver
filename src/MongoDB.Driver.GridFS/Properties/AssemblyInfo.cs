/* Copyright 2015-present MongoDB Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MongoDB.Bson;

[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]

// Prevents the Xamarin static linker from stripping anything from this assembly.
// Required for most of the reflection usage in Xamarin.iOS/Xamarin.Mac.
[assembly: Preserve(AllMembers = true)]

[assembly: InternalsVisibleTo("MongoDB.Driver.GridFS.Tests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100659abd0c112430689b2720dc666436defacccd98f7ceb36fa9a2480ec0d54d0f22e5ad014e85e689a8ed2892a3d8180af106dd9d361ded7a0355de7f8931e29d62ec91edf68379ac37381ea5f4b89d049308a813b26079e4763ff4d264afbd1687073358dc375cf3b440b0788dae4f7dd40da62196fa743aaf69e98ca6044bba")]
