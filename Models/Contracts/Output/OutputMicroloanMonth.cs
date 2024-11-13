using Models.Models;
using System.Text.Json.Serialization;

namespace Models.Contracts.Output;

public class OutputMicroloanMonth
{
    [JsonPropertyName("sum")]
    public float Sum { get; set; }
    [JsonPropertyName("time")]
    public uint Time { get; set; }
    [JsonPropertyName("rate")]
    public float Rate { get; set; }

    public OutputMicroloanMonth(Money m)
    {
        Sum = m.Sum;
        Time = m.Time;
        Rate = m.Rate;
    }
}
