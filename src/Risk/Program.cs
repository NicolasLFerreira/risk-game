using Risk.World;
using Risk.Teams;

using System;
using Risk.Loader;

namespace Risk
{

    class Program
    {
        static void Main(string[] args)
        {
            FileSelector fileSelector = new();
            CountryLoader countryLoader = new(fileSelector.SelectFile(1));
            WorldMap worldMap = new(countryLoader.Transform());

            worldMap.Profile(0);
            Console.WriteLine();

            return;
        }
    }
}