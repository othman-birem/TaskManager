using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Server.Models.Joiners
{
    public class Assignment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid TaskId { get; set; }

        [ForeignKey(nameof(TaskId))]
        public Task Task { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserAccount User { get; set; }
    }

}
