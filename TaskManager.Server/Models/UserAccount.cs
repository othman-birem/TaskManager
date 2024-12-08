using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using TaskManager.Server.Models.Common;

namespace TaskManager.Server.Models
{
    public class UserAccount
    {
        [Key]
        [JsonConverter(typeof(StringToGuidConverter))]
        public Guid Id { get; set; }

        [AllowNull]
        [JsonConverter(typeof(StringToNullableGuidConverter))]
        public Guid? TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        public Team? Team { get; set; }

        [Required]
        [StringLength(100)]
        public string fullName { get; set; }

        [Required]
        public DateTime dateOfBirth { get; set; }

        [Required]
        public string occupation { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        [PasswordPropertyText]
        public string password { get; set; }

        [Required]
        [EnumDataType(typeof(MetaData.AccessPrivileges))]
        [JsonConverter(typeof(NumberToEnumConverter))]
        public MetaData.AccessPrivileges AccessPrivilege { get; set; }
    }
}
