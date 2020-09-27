using Battleship.AI.AITester;
using NUnit.Framework;

namespace Battleship.AI.UnitTests.AITester
{
    public class MapTests
    {
        [Test]
        public void When_deserializing_maps_should_stay_the_same()
        {
            var map = new Map();
            var wasPlaced = map.TryPlace(Ship.Battleship, (0, 0), Direction.North);
            Assert.That(wasPlaced, Is.True);

            var serialized = map.Serialize();

            var deserialized = Map.Deserialize(serialized);
            var shouldNotPlace = map.TryPlace(Ship.Submarine, (0, 0), Direction.East);
            Assert.That(shouldNotPlace, Is.False);

            var shouldPlace = map.TryPlace(Ship.Submarine, (0, 4), Direction.East);
            Assert.That(shouldPlace, Is.True);
        }

        [Test]
        public void When_shooting_misses()
        {
            var map = new Map();
            map.TryPlace(Ship.Battleship, (0, 0), Direction.North);

            var result = map.Shoot((1, 1));
            Assert.That(result, Is.EqualTo(FireResult.Miss));
        }

        [Test]
        public void When_shooting_hits()
        {
            var map = new Map();
            map.TryPlace(Ship.Battleship, (0, 0), Direction.North);

            var result = map.Shoot((0, 0));
            Assert.That(result, Is.EqualTo(FireResult.Hit));
        }

        [Test]
        public void When_sinking_a_vertical_ship()
        {
            var map = new Map();
            map.TryPlace(Ship.Battleship, (0, 0), Direction.North);
            map.Shoot((0, 0));
            map.Shoot((0, 1));
            map.Shoot((0, 2));
            var result = map.Shoot((0, 3));
            Assert.That(result, Is.EqualTo(FireResult.Sink));
        }

        [Test]
        public void When_sinking_a_horizontal_ship()
        {
            var map = new Map();
            map.TryPlace(Ship.Battleship, (0, 0), Direction.East);
            map.Shoot((0, 0));
            map.Shoot((1, 0));
            map.Shoot((2, 0));
            var result = map.Shoot((3, 0));
            Assert.That(result, Is.EqualTo(FireResult.Sink));
        }

        [Test]
        public void When_sinking_a_ship_in_the_top_right()
        {
            var map = new Map();
            map.TryPlace(Ship.Battleship, (9, 9), Direction.South);
            var firstHit = map.Shoot((9, 6));
            Assert.That(firstHit, Is.EqualTo(FireResult.Hit));
            map.Shoot((9, 7));
            var almostDead = map.Shoot((9, 8));
            Assert.That(almostDead, Is.EqualTo(FireResult.Hit));
            var shouldSink = map.Shoot((9, 9));
            Assert.That(shouldSink, Is.EqualTo(FireResult.Sink));
        }

        [Test]
        public void When_checking_if_the_map_is_won()
        {
            var map = new Map();
            map.TryPlace(Ship.Battleship, (0, 0), Direction.North);
            map.Shoot((0, 0));
            map.Shoot((0, 1));
            map.Shoot((0, 2));
            Assert.That(map.IsWon(), Is.False);

            map.Shoot((0, 3));
            Assert.That(map.IsWon(), Is.True);
        }
    }
}
