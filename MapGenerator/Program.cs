using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace MapGenerator
{
    class Program
    {
        const int MapsPerFile = 1000;
        static void Main(string[] args)
        {
            
            if(args.Length != 1)
            {
                Console.WriteLine("Incorrect arguments. Usage: dotnet run -- <outputFilename>");
            }
            var maps = new List<Map>();
            var placer = new BattleshipPlacer();
            for(int i = 0; i < MapsPerFile; i ++)
            {
                maps.Add(placer.GenerateMap());
            }
            System.IO.File.WriteAllText(args[0], JsonConvert.SerializeObject(maps.Select(x => x.Serialize()), Formatting.Indented));
        }
    }
}
