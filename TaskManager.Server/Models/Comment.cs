using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Server.Models
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid TaskId { get; set; }

        [ForeignKey(nameof(TaskId))]
        public Task task { get; set; }

        [Required]
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public UserAccount userAccount { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "The comment content cannot exceed 300 characters.")]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public Comment()
        {

        }

        public void EditContent(string replacement)
        {

        }
    }
}
