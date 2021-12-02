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
            // var b = new Benchmark();
            // var a1 = b.ReflectionSerialization();
            // var a2 = b.SourceGeneratorSerialization();
            // var a3 = b.ReflectionDeSerialization();
            // var a4 = b.SourceGeneratorDeSerialization();
            
            var summary = BenchmarkRunner.Run<Benchmark>();
            
            // local results: Source Generator Serialization ~22 % faster, Deserialization ~2% slower
            // |                         Method |     Mean |   Error |  StdDev |
            // |------------------------------- |---------:|--------:|--------:|
            // |        ReflectionSerialization | 278.0 ns | 5.23 ns | 9.57 ns |
            // |   SourceGeneratorSerialization | 218.6 ns | 4.44 ns | 5.28 ns |
            // |      ReflectionDeSerialization | 369.9 ns | 7.41 ns | 6.57 ns |
            // | SourceGeneratorDeSerialization | 373.9 ns | 3.95 ns | 3.30 ns |

        }
    }
}