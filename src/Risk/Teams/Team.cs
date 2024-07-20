using Risk.World;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk.Teams
{
    internal class Team
    {
        public TeamColour Colour { get; }
        public string Name { get; set; }
        public List<Country> CountryList { get; set; }

        public Team(TeamColour colour, string name, List<Country> countryList)
        {
            Colour = colour;
            Name = name;
            CountryList = countryList;
        }
    }
}
