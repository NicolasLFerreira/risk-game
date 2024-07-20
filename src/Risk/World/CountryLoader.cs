using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Risk.World
{
    internal class CountryLoader
    {
        // Classes for the raw data

        private class CountriesList
        {
            public CountryInfo[]? Countries { get; set; }
        }

        private class CountryInfo
        {
            public string? Name { get; set; }
            public string? Code { get; set; }
            public string[]? Neighbours { get; set; }
        }

        // Default path to country JSON file
        private const string defaultPath = @"C:\Users\nicol\source\repos\Risk\src\Risk\World\countries.json";

        // List of country objects from JSON file
        CountriesList RawCountries { get; }

        public CountryLoader(string path = defaultPath)
        {
            // Load from test.json
            string jsonString = File.ReadAllText(path);
            RawCountries = JsonSerializer.Deserialize<CountriesList>(jsonString) ?? new CountriesList();
        }

        // Transforms the raw country list into a OrderedDictionary object
        public OrderedDictionary Transform()
        {
            OrderedDictionary countries = new();

            // Load countries first

            if (RawCountries.Countries != null)
            {
                foreach (var item in RawCountries.Countries)
                {
                    if (item.Name != null && item.Code != null && item.Neighbours != null)
                    {
                        countries.Add(new Country(item.Name, item.Code));
                    }
                }
            }

            // Add neighbours to existing country objects

            if (RawCountries.Countries != null)
            {
                foreach (var item in RawCountries.Countries)
                {
                    if (item.Name != null && item.Code != null && item.Neighbours != null)
                    {
                        Country currentCountry = countries[item.Code]; // Correctly reference the Country object
                        foreach (string code in item.Neighbours)
                        {
                            if (countries.Contains(countries[code])) // Ensure the neighbor exists
                            {
                                currentCountry.Countries.Add(countries[code]); // Add the neighbor to the Countries property
                            }
                        }
                    }
                }
            }

            return countries;
        }
    }
}
