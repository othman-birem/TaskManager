using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TaskManager.Server.Models.Joiners
{
    public class Assignment
    {
        [Key]
        [JsonConverter(typeof(StringToGuidConverter))]
        public Guid Id { get; set; }

        [JsonConverter(typeof(StringToNullableGuidConverter))]
        public Guid? TaskId { get; set; }

        [ForeignKey(nameof(TaskId))]
        public Task Task { get; set; }

        [JsonConverter(typeof(StringToNullableGuidConverter))]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserAccount User { get; set; }
    }

}
