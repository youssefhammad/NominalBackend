﻿using System.Text.Json.Serialization;

namespace NominalBackend.Helpers.Enums
{
    public class Enumerators
    {
        public enum UserState
        {
            [JsonPropertyName("active_account")]
            ActiveAccount,
            [JsonPropertyName("blocked_account")]
            BlockedAccount,
            [JsonPropertyName("deleted_account")]
            DeletedAccount,
        }
    }

    public enum State 
    {
        [JsonPropertyName("active")]
        Active,
        [JsonPropertyName("soft_deleted")]
        SoftDeleted
    }

    public enum  UserRole
    {

        [JsonPropertyName("client")]
        Client,
        [JsonPropertyName("admin")]
        Admin
    }

    public enum PaymentStatus
    {
        [JsonPropertyName("pending")]
        Pending,
        [JsonPropertyName("done")]
        Done
    }

    public enum Sorting
    {
        [JsonPropertyName("ascending")]
        Ascending,
        [JsonPropertyName("descending")]
        Descending
    }

    public enum SortedBy
    {
        [JsonPropertyName("price")]
        Price,
        [JsonPropertyName("created_at")]
        CreatedAt
    }
}
