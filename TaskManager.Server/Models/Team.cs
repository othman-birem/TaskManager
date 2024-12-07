using System.ComponentModel.DataAnnotations;

namespace TaskManager.Server.Models
{
    public class Team
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
