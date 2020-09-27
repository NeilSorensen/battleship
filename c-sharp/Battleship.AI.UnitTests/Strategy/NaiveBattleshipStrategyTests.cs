using Battleship.AI.Strategy;
using NUnit.Framework;

namespace Battleship.AI.UnitTests.Strategy
{
    public class NaiveBattleshipStrategyTests
    {
        [Test]
        public void When_starting_a_new_game()
        {
            var classUnderTest = new NaiveBattleshipStrategy();
            var target = classUnderTest.GetNextMove(FireResult.None);
            Assert.That(target, Is.EqualTo((0,0)));
        }

        [Test]
        public void When_making_subsequent_moves_it_should_increment_x()
        {
            var classUnderTest = new NaiveBattleshipStrategy();
            classUnderTest.GetNextMove(FireResult.None);
            var target = classUnderTest.GetNextMove(FireResult.Miss);
            Assert.That(target, Is.EqualTo((1, 0)));
        }

        [Test]
        public void When_reaching_the_end_of_a_row_it_should_start_at_the_beginning_of_the_next_row()
        {
            var classUnderTest = new NaiveBattleshipStrategy();
            classUnderTest.GetNextMove(FireResult.None);
            for (int i = 0; i < 9; i++) // Since we already had one, we need 9 more to finish the row
            {
                classUnderTest.GetNextMove(FireResult.Hit);
            }

            var target = classUnderTest.GetNextMove(FireResult.Sink);
            Assert.That(target, Is.EqualTo((0,1)));
        }

    }
}
