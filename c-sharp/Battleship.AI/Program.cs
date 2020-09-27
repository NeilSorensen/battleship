using System;
using System.Collections.Generic;
using System.IO;
using Battleship.AI.AITester;
using Newtonsoft.Json;

namespace Battleship.AI
{
    class Program
    {
        static void Main(string[] args)
        {
            var testFile = File.ReadAllText(args[0]);
            var maps = JsonConvert.DeserializeObject<List<string>>(testFile);
            var simulator = new GameSimulator();
            simulator.SimulateAllGames(maps);
        }
    }
}
