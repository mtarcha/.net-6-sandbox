using System;
using System.Diagnostics;
using System.Text.Json;
using BenchmarkDotNet.Running;

namespace SourceGenerator
{
    public class Program
    {
        private static JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        
        private static void Main()
        {
            var person = new WorkDetails
            {
                CompanyName = "RTL",
                Position = ".NET developer"
            };
            
            SourceGeneratorSerialization(person);
            ReflectionSerialization(person);
            
            var summary = BenchmarkRunner.Run<Benchmark>();
        }

        private static void ReflectionSerialization(WorkDetails workDetails)
        {
            var serialized = JsonSerializer.Serialize(workDetails, _options);
            Console.WriteLine(serialized);
        }
        
        private static void SourceGeneratorSerialization(WorkDetails workDetails)
        {
            var serialized = JsonSerializer.Serialize(workDetails, WorkDetailsJsonContext.Default.WorkDetails);
            Console.WriteLine(serialized);
        }
    }
}