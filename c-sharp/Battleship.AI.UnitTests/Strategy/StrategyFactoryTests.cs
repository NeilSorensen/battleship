using Battleship.AI.Strategy;
using NUnit.Framework;

namespace Battleship.AI.UnitTests.Strategy
{
    public class StrategyFactoryTests
    {
        [Test]
        public void When_getting_the_strategy_to_use()
        {
            var chosenStrategy = StrategyFactory.GetStrategy();
            Assert.That(chosenStrategy, Is.InstanceOf<NaiveBattleshipStrategy>());
        }
    }
}
