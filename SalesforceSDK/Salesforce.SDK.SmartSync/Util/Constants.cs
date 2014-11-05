﻿/*
 * Copyright (c) 2014, salesforce.com, inc.
 * All rights reserved.
 * Redistribution and use of this software in source and binary forms, with or
 * without modification, are permitted provided that the following conditions
 * are met:
 * - Redistributions of source code must retain the above copyright notice, this
 * list of conditions and the following disclaimer.
 * - Redistributions in binary form must reproduce the above copyright notice,
 * this list of conditions and the following disclaimer in the documentation
 * and/or other materials provided with the distribution.
 * - Neither the name of salesforce.com, inc. nor the names of its contributors
 * may be used to endorse or promote products derived from this software without
 * specific prior written permission of salesforce.com, inc.
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE
 * LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
 * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
 * POSSIBILITY OF SUCH DAMAGE.
 */

using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Salesforce.SDK.Auth;
using Salesforce.SDK.SmartStore.Store;

namespace Salesforce.SDK.SmartSync.Util
{
    /// <summary>
    ///     This class contains commonly used constants such as field names, SObject types, attribute names, etc.
    /// </summary>
    public static class Constants
    {
        public const string NullString = "null";
        public const string Id = "Id";
        public const string Name = "Name";
        public const string Type = "Type";
        public const string Attributes = "Attributes";
        public const string RecentlyViewed = "RecentlyViewed";
        public const string Records = "records";
        public const string Lid = "id"; // lower case id in create response
        public const string SobjectType = "attributes.type";
        public const string NextRecordsUrl = "nextRecordsUrl";
        public const string TotalSize = "totalSize";
        public const string RecentItems = "recentItems";

        /**
         * Salesforce object types.
         */
        public const string Account = "Account";
        public const string Lead = "Lead";
        public const string Case = "Case";
        public const string Opportunity = "Opportunity";
        public const string Task = "Task";
        public const string Contact = "Contact";
        public const string Campaign = "Campaign";
        public const string User = "User";
        public const string Group = "CollaborationGroup";
        public const string Dashboard = "Dashboard";
        public const string Content = "ContentDocument";
        public const string ContentVersion = "ContentVersion";

        /**
         * Salesforce object type field constants.
         */
        public const string KeyprefixField = "keyPrefix";
        public const string NameField = "name";
        public const string LabelField = "label";
        public const string LabelpluralField = "labelPlural";
        public const string FieldsField = "fields";
        public const string LayoutableField = "layoutable";
        public const string SearchableField = "searchable";
        public const string HiddenField = "deprecatedAndHidden";
        public const string NameFieldField = "nameField";
        public const string NetworkidField = "NetworkId";
        public const string NetworkscopeField = "NetworkScope";

        /**
         * Salesforce object layout column field constants.
         */
        public const string LayoutNameField = "name";
        public const string LayoutFieldField = "field";
        public const string LayoutFormatField = "format";
        public const string LayoutLabelField = "label";

        /**
         * Salesforce object type layout field constants.
         */
        public const string LayoutLimitsField = "limitRows";
        public const string LayoutColumnsField = "searchColumns";

        /**
         * SyncState, SyncOptions, Status constants
         */

        public const string SyncsSoup = "syncs_soup";
        public const string SyncType = "type";
        public const string SyncTarget = "target";
        public const string SyncOptions = "options";
        public const string SyncSoupName = "soupName";
        public const string SyncStatus = "status";
        public const string SyncProgress = "progress";
        public const string SyncTotalSize = "totalSize";
        public const string SyncAsString = "syncAsString";
        public const string FieldList = "fieldlist";
        public const string QueryType = "type";
        public const string Query = "query";
        public const string Fieldlist = "fieldlist";
        public const string SObjectType = "sobjectType";
        /**
         * Helper static methods
         */

        public static string GenerateAccountCommunityId(Account account, string communityId)
        {
            if (account == null)
            {
                throw new SmartStoreException("Account cannot be null");
            }
            string uniqueId;
            if (Account.InternalCommunityId.Equals(communityId))
            {
                communityId = null;
            }
            if (!String.IsNullOrWhiteSpace(communityId))
            {
                uniqueId = account.UserId + communityId;
            }
            else
            {
                uniqueId = account.UserId;
            }
            return uniqueId;
        }

        /**
         * Helper extension method
         */

        public static T Get<T>(this Dictionary<string, object> dict, string keyName)
        {
            object value;
            dict.TryGetValue(keyName, out value);
            return (T) value;
        }

        public static T ExtractValue<T>(this JObject obj, string valueName)
        {
            JToken value = null;
            if (obj.TryGetValue(valueName, out value))
            {
                return value.Value<T>();
            }
            return default(T);
        }
    }
}