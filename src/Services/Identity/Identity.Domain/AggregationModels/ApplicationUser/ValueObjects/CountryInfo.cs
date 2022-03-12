using System.Text.Json.Serialization;

namespace Identity.Domain.AggregationModels.ApplicationUser.ValueObjects;

public sealed class CountryInfo
{
    [JsonPropertyName("country")]
    public string ISO { get; private set; }
    public string Name { get; private set; }

    public CountryInfo(string country, string region)
    {
        ISO = country ?? throw new ArgumentException(nameof(country));
        Name = region ?? throw new ArgumentException(nameof(region));
    }
}