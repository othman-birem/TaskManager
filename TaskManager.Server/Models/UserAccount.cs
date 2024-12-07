using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.Server.Models.Common;

#nullable disable

namespace TaskManager.Server.Models
{
    public class UserAccount
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid TeamId { get; set; }
        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; }
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
        public MetaData.AccessPrivileges AccessPrivilege { get; set; }
    }
}
