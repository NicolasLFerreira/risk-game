using Risk.World;
using Risk.Teams;

using System;

namespace Risk
{

    class Program
    {
        static void Main(string[] args)
        {
            WorldMap wm = new();

            wm.ListAll();
            Console.WriteLine($"{wm.AreNeighbours("br", "uy")}");
            Console.WriteLine($"{wm.AreNeighbours("br", "cl")}");
            Console.WriteLine();

            wm.Countries["br"].Team = TeamColour.Green;
            wm.Countries["uy"].Team = TeamColour.Red;

            wm.Profile("br");
            wm.Profile("uy");
            return;
        }
    }
}