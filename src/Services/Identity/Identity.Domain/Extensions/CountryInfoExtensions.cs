using System.Collections.Immutable;
using System.Globalization;
using Identity.Domain.AggregationModels.ApplicationUser.ValueObjects;

namespace Identity.Domain.Extensions;

public static class CountryInfoExtensions
{
    public static IEnumerable<CountryInfo> GetCountriesDict(this CountryInfo country)
    {
        var countriesInfo = new List<CountryInfo>();

        var cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

        foreach (var culture in cultures)
        {
            var regionInfo = new RegionInfo(culture.LCID);
            if (countriesInfo.Any(x => x.ISO == culture.ThreeLetterISOLanguageName))
            {
                var countryInfo = new CountryInfo(regionInfo.ThreeLetterISORegionName, regionInfo.EnglishName);
                countriesInfo.Add(countryInfo);
            }
        }

        return countriesInfo.OrderBy(item => item.Name);
    }
}