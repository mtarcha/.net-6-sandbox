using System;
using System.Text.Json.Serialization;

namespace SourceGenerator
{
    public class WorkDetails
    {
        [JsonPropertyName("bla_1")]
        public string CompanyName { get; set; }
        
        [JsonPropertyName("bla_2")]
        public string Position { get; set; }
    }
}