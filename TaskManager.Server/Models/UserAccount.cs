using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TaskManager.Server.Models
{
    public class UserAccount
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string secondName { get; set; }
        [Required]
        public DateTime dateOfBirth { get; set; }
        [Required]
        public string occupation { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6)]
        [PasswordPropertyText]
        public string password { get; set; }
    }
}
