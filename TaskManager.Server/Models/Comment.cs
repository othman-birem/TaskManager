using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TaskManager.Server.Models
{
    public class Comment
    {
        [Key]
        [JsonConverter(typeof(StringToGuidConverter))]
        public Guid Id { get; set; }

        [JsonConverter(typeof(StringToGuidConverter))]
        public Guid TaskId { get; set; }

        [ForeignKey(nameof(TaskId))]
        public Task task { get; set; }

        [JsonConverter(typeof(StringToGuidConverter))]
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
