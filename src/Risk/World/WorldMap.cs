using Risk.Teams;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk.World
{
    internal class WorldMap
    {
        public OrderedDictionary Countries { get; set; }

        public WorldMap()
        {
            CountryLoader countryLoader = new();
            Countries = countryLoader.Transform();
        }

        public void AddRelationship(string country1, string country2)
        {
            Countries[country1].Countries.Add(Countries[country2]);
            Countries[country2].Countries.Add(Countries[country1]);
        }

        public bool AreNeighbours(string country1, string country2)
        {
            return Countries[country1].Countries.Contains(Countries[country2]);
        }

        // Info dumping

        public void ListNeighbours(string code)
        {
            foreach (var country in Countries[code].Countries)
            {
                Console.WriteLine($"--{country.Name} ({country.Code})");
            }
        }

        public void ListAll()
        {
            foreach (var country in Countries)
            {
                Console.WriteLine($"#={country.Name} ({country.Code}):");
                ListNeighbours(country.Code);

                Console.WriteLine();
            }
        }

        public void Profile(string code)
        {
            Country country = Countries[code];

            if (country.Team >= 0)
                Console.ForegroundColor = (ConsoleColor)country.Team;

            Console.WriteLine($"Name: {country.Name}");
            Console.WriteLine($"Code: {country.Code}");
            Console.WriteLine($"Team: {country.Team}");
            Console.WriteLine($"Unit: {country.Units}");
            Console.WriteLine("Neighbours:");
            ListNeighbours(code);

            Console.ResetColor();
        }
    }
}
