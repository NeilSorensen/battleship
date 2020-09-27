using System;
using System.Collections.Generic;
using Battleship.AI.Strategy;
using MathNet.Numerics.Statistics;

namespace Battleship.AI.AITester
{
    public class GameSimulator
    {
        public int SimulateGame(ITestMap map, IBattleshipStrategy strategy)
        {
            var turnCount = 0;
            var nextTarget = strategy.GetNextMove(FireResult.None);
            do
            {
                turnCount++;
                var result = map.Shoot(nextTarget);
                nextTarget = strategy.GetNextMove(result);
            } while (!map.IsWon());

            return turnCount;
        }

        public void SimulateAllGames(List<string> gameStates)
        {
            List<double> turnCounts = new List<double>();
            Console.WriteLine($"Preparing to run {gameStates.Count} simulations:");

            foreach (var gameState in gameStates)
            {
                var map = Map.Deserialize(gameState);
                var strategy = StrategyFactory.GetStrategy();
                turnCounts.Add(SimulateGame(map, strategy));
                Console.Write(".");
            }
            Console.WriteLine();
            Console.WriteLine("All simulations complete!");
            var statistics = new DescriptiveStatistics(turnCounts);

            Console.WriteLine($"Average number of turns required: {statistics.Mean}");
            Console.WriteLine($"Minimum number of turns required: {statistics.Minimum}");
            Console.WriteLine($"Maximum number of turns required: {statistics.Maximum}");
            Console.WriteLine($"Standard Deviation: {statistics.StandardDeviation}");
            Console.WriteLine($"Skewness (0 represents a normal distribution): {statistics.Skewness}");
        }
    }
}
