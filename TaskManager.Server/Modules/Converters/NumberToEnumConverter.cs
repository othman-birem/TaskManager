using System.Text.Json;
using System.Text.Json.Serialization;
using TaskManager.Server.Models.Common;

namespace TaskManager.Server.Modules.Converters
{
    public class NumberToEnumConverter : JsonConverter<MetaData.AccessPrivileges>
    {
        public override MetaData.AccessPrivileges Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var Value = reader.GetString();
            Console.WriteLine(Value);
            return 0;

        }

        public override void Write(Utf8JsonWriter writer, MetaData.AccessPrivileges value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
