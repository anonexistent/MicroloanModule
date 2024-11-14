using Models.Models;
using System.Text.Json.Serialization;

namespace Models.Contracts.Output;

public class OutputMicroloanMonth
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonPropertyName("sum")]
    public float Sum { get; set; }
    [JsonPropertyName("time")]
    public uint Time { get; set; }
    [JsonPropertyName("rate")]
    public float Rate { get; set; }

    public OutputMicroloanMonth(Money m)
    {
        Id = m.Id.ToString();
        Sum = m.Sum;
        Time = m.Time;
        Rate = m.Rate;
    }
}
