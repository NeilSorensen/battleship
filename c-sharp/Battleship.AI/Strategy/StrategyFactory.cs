using System;

namespace Battleship.AI.Strategy
{
    public static class StrategyFactory
    {
        /// <summary>
        /// GetStrategy will be executed before beginning each game, so you can preserve state between
        /// turns but reset state between games here.
        /// </summary>
        /// <returns></returns>
        public static IBattleshipStrategy GetStrategy()
        {
            return new NaiveBattleshipStrategy();
        }
    }
}
