using System;
using System.Collections.Generic;
using System.IO;
using Battleship.AI.AITester;
using System.Text.Json;

namespace Battleship.AI
{
    class Program
    {
        static void Main(string[] args)
        {
            var testFile = File.ReadAllText(args[0]);
            var maps = JsonSerializer.Deserialize<List<string>>(testFile);
            var simulator = new GameSimulator();
            simulator.SimulateAllGames(maps);
        }
    }
}
