using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TaskManager.Server.Models.Common;

namespace TaskManager.Server.Models
{
    public class Task
    {
        [Key]
        [JsonConverter(typeof(StringToGuidConverter))]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [JsonConverter(typeof(StringToGuidConverter))]
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
