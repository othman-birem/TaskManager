using System.ComponentModel.DataAnnotations;

namespace TaskManager.Server.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
    }
}
