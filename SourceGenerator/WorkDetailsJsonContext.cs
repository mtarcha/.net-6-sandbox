using System.Text.Json.Serialization;

namespace SourceGenerator
{
    [JsonSerializable(typeof(WorkDetails))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    public partial class WorkDetailsJsonContext : JsonSerializerContext
    {
        
    }
}