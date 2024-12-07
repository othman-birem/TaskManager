using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.Server.Models.Common;

namespace TaskManager.Server.Models
{
    public class Task
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        [Required]
        [EnumDataType(typeof(MetaData.TaskStatus))]
        public MetaData.TaskStatus Status { get; set; }

        [Required]
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime DueDate { get; set; }

        public Task()
        {
        }

        public void Assign(Guid userId)
        {

        }

        public void ChangeStatus(MetaData.TaskStatus status)
        {
            Status = status;
        }
    }
}
