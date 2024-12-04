using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Server.Models
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [ForeignKey(nameof(Task.Id))]
        public string TaskId { get; set; }
        [Required]
        [ForeignKey(nameof(UserAccount.Id))]
        public string UserId { get; set; }
        [Required]
        [MaxLength(300, ErrorMessage = "The comment content cannot exceed 300 characters.")]
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
