using Risk.Teams;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk.World
{
    internal class Country
    {
        // Properties
        /// <summary>
        /// Display name of the country.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Alpha-2 code of the country. Used as ID.
        /// </summary>
        public string Code { get; }
        public TeamColour Team { get; set; }
        public int Units { get; private set; }

        /// <summary>
        /// List and dictionary combo of neighbouring countries.
        /// </summary>
        public OrderedDictionary Countries { get; set; }

        // Constructors

        public Country(string name, string countryCode, TeamColour team, int units)
        {
            Name = name;
            Code = countryCode;
            Team = team;
            Units = units;
            Countries = new();
        }

        public Country(string name, string countryCode, TeamColour team) : this(name, countryCode, team, 0) { }

        public Country(string name, string countryCode) : this(name, countryCode, TeamColour.None) { }

        public Country() : this("EMPTY", "00") { }

        // Unit handling

        public void AllocateUnits(int amount)
        {
            Units += amount;
        }

        public void RemoveUnit()
        {
            Units--;
        }
    }
}
