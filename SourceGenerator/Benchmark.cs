using System.Text.Json;
using BenchmarkDotNet.Attributes;

namespace SourceGenerator;

public class Benchmark
{
    private WorkDetails _details = new WorkDetails
    {
        CompanyName = "RTL",
        Position = ".NET developer"
    };
    
    private static JsonSerializerOptions _options = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    [Benchmark]
    public string ReflectionSerialization()
    {
        return JsonSerializer.Serialize(_details, _options);
    }
        
    [Benchmark]
    public string SourceGeneratorSerialization()
    {
        return JsonSerializer.Serialize(_details, WorkDetailsJsonContext.Default.WorkDetails);
    }
}