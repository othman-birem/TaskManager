using System.Text.Json;
using System.Text.Json.Serialization;

namespace TaskManager.Server.Modules.Converters
{
    public class StringToGuidConverter : JsonConverter<Guid>
    {
        public override Guid Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var stringValue = reader.GetString();

            if(string.IsNullOrEmpty(stringValue)) { return Guid.Empty; }

            return Guid.TryParse(stringValue, out var guid) ? guid : throw new JsonException("Invalid GUID format.");
        }

        public override void Write(Utf8JsonWriter writer, Guid value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
