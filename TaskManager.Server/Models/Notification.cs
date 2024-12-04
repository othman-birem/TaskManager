using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.Server.Models.Common;

namespace TaskManager.Server.Models
{
    public class Notification
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [ForeignKey(nameof(UserAccount.Id))]
        public string UserId { get; set; }
        [Required]
        public DateTime DeliveredAt { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        [DataType("integer")]
        public MetaData.NotificationType Type { get; set; }
        [Required]
        public bool IsRead { get; set; }

        public Notification()
        {

        }

        public void MarkAsRead()
        {

        }
    }
}
