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

// TODO:
// [ ] Contracts
// [ ] Documentation

namespace Splunk.Client
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ApplicationUpdateInfo : Entity<ApplicationUpdateInfo>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUpdateInfo"/>
        /// class.
        /// </summary>
        /// <param name="context">
        /// An object representing a Splunk server session.
        /// </param>
        /// <param name="ns">
        /// An object identifying a Splunk services namespace.
        /// </param>
        /// <param name="name">
        /// The name of a Splunk application.
        /// </param>
        internal ApplicationUpdateInfo(Context context, Namespace ns, string name)
            : base(context, ns, new ResourceName(ApplicationCollection.ClassResourceName, name, "update"))
        { }

        /// <summary>
        /// Infrastructure. Initializes a new instance of the <see cref=
        /// "ApplicationUpdateInfo"/> class.
        /// </summary>
        /// <remarks>
        /// This API supports the Splunk client infrastructure and is not 
        /// intended to be used directly from your code. The <see cref=
        /// "ApplicationUpdateInfo"/> class is an information object
        /// returned by these methods.
        /// <list type="table">
        /// <listheader>
        ///   <term>Method</term>
        ///   <description>Description</description>
        /// </listheader>
        /// <item>
        ///   <term><see cref="Application.GetUpdateInfoAsync"/></term>
        ///   <description>
        ///   Asynchronously retrieves update information for the current <see 
        ///   cref="Application"/>.
        /// </description>
        /// </item>
        /// <item>
        ///   <term><see cref="Service.GetApplicationUpdateInfoAsync"/></term>
        ///   <description>
        ///   Asynchronously retrieves update information for an <see cref=
        ///   "Application"/> identified by name.
        ///   </description>
        /// </item>
        /// </remarks>
        public ApplicationUpdateInfo()
        { }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the access control lists for the current instance.
        /// </summary>
        public Eai Eai
        {
            get { return this.GetValue("Eai", Eai.Converter.Instance); }
        }

        /// <summary>
        /// Gets the properties of the update.
        /// </summary>
        /// <remarks>
        /// A value of <c>null</c> indicates that no update is available.
        /// </remarks>
        public Update_t Update
        {
            get { return this.GetValue("Update", Update_t.Converter.Instance); }
        }

        /// <summary>
        /// Gets a value indicating whether to to reload the objects contained 
        /// in the locally installed application.
        /// </summary>
        public bool Refresh
        {
            get { return this.GetValue("Refresh", BooleanConverter.Instance); }
        }

        #endregion

        #region Types

        public class Update_t : ExpandoAdapter<Update_t>
        {
            public Update_t()
            {  }

            /// <summary>
            /// Get the name of the application.
            /// </summary>
            public string ApplicationName
            {
                get { return this.GetValue("Name", StringConverter.Instance); }
            }

            /// <summary>
            /// Gets the download URI for the application update.
            /// </summary>
            public Uri ApplicationUri
            {
                get { return this.GetValue("Appurl", UriConverter.Instance); }
            }

            /// <summary>
            /// Gets the checksum for the application update.
            /// </summary>
            public string Checksum
            {
                get { return this.GetValue("Checksum", StringConverter.Instance); }
            }

            /// <summary>
            /// Gets the name of the checksum type used to compute the application
            /// update <see cref="Checksum"/>.
            /// </summary>
            public string ChecksumType
            {
                get { return this.GetValue("ChecksumType", StringConverter.Instance); }
            }

            /// <summary>
            /// Get the URI to the Splunkbase page for the application.
            /// </summary>
            public string HomePage
            {
                get { return this.GetValue("Homepage", StringConverter.Instance); }
            }

            /// <summary>
            /// Gets a value that indicates if the application has an explicit 
            /// ID in app.conf.
            /// </summary>
            /// <remarks>
            /// Splunk uses application IDs to help identify them during updates.
            /// </remarks>
            public bool ImplicitIdRequired
            {
                get { return this.GetValue("ImplicitIdRequired", BooleanConverter.Instance); }
            }

            /// <summary>
            /// Get the size of the application update.
            /// </summary>
            public long Size
            {
                get { return this.GetValue("Size", Int64Converter.Instance); }
            }

            /// <summary>
            /// Get the version of the application update.
            /// </summary>
            public string Version
            {
                get { return this.GetValue("Version", StringConverter.Instance); }
            }
        }

        #endregion
    }
}
