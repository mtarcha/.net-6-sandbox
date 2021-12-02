using System;
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

    private string _deserializeString = "{\"bla_1\":\"RTL\",\"bla_2\":\".NET developer\"}";
    
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
    
    [Benchmark]
    public WorkDetails ReflectionDeSerialization()
    {
        return JsonSerializer.Deserialize<WorkDetails>(_deserializeString, _options);
    }
        
    [Benchmark]
    public WorkDetails SourceGeneratorDeSerialization()
    {
        return JsonSerializer.Deserialize(_deserializeString, WorkDetailsJsonContext.Default.WorkDetails);
    }
}