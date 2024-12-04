using System.ComponentModel.DataAnnotations;

namespace TaskManager.Server.Models
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Role()
        {

        }
    }
}
