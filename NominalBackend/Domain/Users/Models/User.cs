using NominalBackend.Domain.Purchases.Models;
using NominalBackend.Domain.Wishlists.Models;
using NominalBackend.Helpers.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static NominalBackend.Helpers.Enums.Enumerators;

namespace NominalBackend.Domain.Users.Models
{
    public class User
    {
        public User()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        public int Id { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [StringLength(16, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 8)]
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("blocked")] 
        public bool Blocked { get; set; }

        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; } 

        [JsonPropertyName("lastName")]
        public string? LastName { get; set; } 

        [JsonPropertyName("nationality")]
        public string? Nationality { get; set; }

        [JsonPropertyName("phone")]
        public string? Phone { get; set; } 

        [JsonPropertyName("birthDate")]
        public string BirthDate { get; set; }

        [JsonPropertyName("gender")] 
        public string? Gender { get; set; } 

        [JsonPropertyName("email_verified")]
        public bool EmailVerified { get; set; }

        [JsonPropertyName("role")] 
        public UserRole Role { get; set; }

        [JsonPropertyName("otp")]
        public string? Otp { get; set; }

        [JsonPropertyName("otp_verified")] 
        public bool OtpVerified { get; set; } 

        [JsonPropertyName("state")]
        public UserState State { set; get; }
        public ICollection<Purchase> Purchases { get; set; }
    }
}
