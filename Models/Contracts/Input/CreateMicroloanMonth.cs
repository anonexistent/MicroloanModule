using System.Text.Json.Serialization;

namespace Models.Contracts.Input;

public record CreateMicroloanMonth
{
    [JsonPropertyName("sum")]
    public float Sum { get; set; }
    [JsonPropertyName("time")]
    public uint Time { get; set; }
    [JsonPropertyName("rate")]
    public float Rate { get; set; }
};
