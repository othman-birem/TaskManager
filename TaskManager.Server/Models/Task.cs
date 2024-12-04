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
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [ForeignKey(nameof(UserAccount.Id))]
        public string AssignedUser { get; set; }
        [Required]
        [ForeignKey(nameof(Category.Id))]
        public string CategoryId { get; set; }
        [Required]
        [DataType("integer")]
        public MetaData.TaskStatus Status { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }

        public Task()
        {

        }

        public void Assign(string user)
        {

        }
        public void ChangeStatus(MetaData.TaskStatus status)
        {

        }
    }
}
