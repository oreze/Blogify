using System.Text.Json.Serialization;

namespace Identity.Domain.AggregationModels.ApplicationUser.ValueObjects;

public sealed class CountryInfo
{
    public Dictionary<string, CountryInfo> Countries { get; }

    public CountryInfo(string code, Dictionary<string, CountryInfo> countries)
    {
        Countries = countries ?? throw new ArgumentNullException(nameof(countries));
    }
    
    public sealed class Country
    {
        [JsonPropertyName("country")]
        public string Name { get; private set; }
        public string Region { get; private set; }

        public Country(string country, string region)
        {
            Name = country ?? throw new ArgumentException(nameof(country));
            Region = region ?? throw new ArgumentException(nameof(region));
        }
    }
}