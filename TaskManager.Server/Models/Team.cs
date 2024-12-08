using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskManager.Server.Models
{
    public class Team
    {
        [Key]
        [JsonConverter(typeof(StringToGuidConverter))]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
