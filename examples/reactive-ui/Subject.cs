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

namespace Splunk.Sdk.Examples.ReactiveUI
{
    using Splunk.Sdk;
    using System.Collections.Generic;
    using System.Reactive.Subjects;

    static class Subject
    {
        static readonly Subject<double> RecordRate = new Subject<double>();
        static readonly Subject<Record> Records = new Subject<Record>();
    }
}