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
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public UserAccount User { get; set; }
        [Required]
        public DateTime DeliveredAt { get; set; }
        [Required]
        [StringLength(1000)]
        public string Content { get; set; }
        [Required]
        [EnumDataType(typeof(MetaData.NotificationType))]
        public MetaData.NotificationType Type { get; set; }
        [Required]
        public bool IsRead { get; set; }

        public Notification()
        {
            IsRead = false;
        }

        public void MarkAsRead()
        {
            IsRead = true;
        }
    }
}
