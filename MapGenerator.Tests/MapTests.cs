using System;
using NUnit.Framework;

namespace MapGenerator.Tests
{
    public class ShipPlacementCheckerTests
    {
        [TestCase(Direction.North, true)]
        [TestCase(Direction.East, true)]
        [TestCase(Direction.South, false)]
        [TestCase(Direction.West, false)]
        public void When_placing_the_carrier_at_0_0_on_an_empty_map(Direction direction, bool shouldBePlaceable)
        {
            var classUnderTest = new Map(10, 10);
            var result = classUnderTest.TryPlace(Ship.Carrier, (0,0), direction);
            Assert.That(result, Is.EqualTo(shouldBePlaceable));
        }

        [TestCase(Direction.North, false)]
        [TestCase(Direction.East, false)]
        [TestCase(Direction.South, true)]
        [TestCase(Direction.West, true)]
        public void When_placing_the_carrier_at_9_9_on_an_empty_map(Direction direction, bool shouldBePlaceable)
        {
            var classUnderTest = new Map(10, 10);
            var result = classUnderTest.TryPlace(Ship.Carrier, (9,9), direction);
            Assert.That(result, Is.EqualTo(shouldBePlaceable));
        }

        [TestCase(Direction.North, true)]
        [TestCase(Direction.East, true)]
        [TestCase(Direction.South, true)]
        [TestCase(Direction.West, true)]
        public void When_placing_the_destroyer_at_1_1_on_an_empty_map(Direction direction, bool shouldBePlaceable)
        {
            var classUnderTest = new Map(10, 10);
            var result = classUnderTest.TryPlace(Ship.Destroyer, (1,1), direction);
            Assert.That(result, Is.EqualTo(shouldBePlaceable));
        }

        [TestCase(Direction.North, true)]
        [TestCase(Direction.East, true)]
        [TestCase(Direction.South, false)]
        [TestCase(Direction.West, false)]
        public void When_placing_the_carrier_at_1_1_on_an_empty_map(Direction direction, bool shouldBePlaceable)
        {
            var classUnderTest = new Map(10, 10);
            var result = classUnderTest.TryPlace(Ship.Carrier, (1,1), direction);
            Assert.That(result, Is.EqualTo(shouldBePlaceable));
        }
        
        [TestCase(Direction.North, true)]
        [TestCase(Direction.East, true)]
        [TestCase(Direction.South, true)]
        [TestCase(Direction.West, true)]
        public void When_placing_the_carrier_at_5_5_on_an_empty_map(Direction direction, bool shouldBePlaceable)
        {
            var classUnderTest = new Map(10, 10);
            var result = classUnderTest.TryPlace(Ship.Carrier, (5,5), direction);
            Assert.That(result, Is.EqualTo(shouldBePlaceable));
        }

        [TestCase(Direction.North, false)]
        [TestCase(Direction.East, false)]
        [TestCase(Direction.South, true)]
        [TestCase(Direction.West, true)]
        public void When_placing_the_carrier_at_6_6_on_an_empty_map(Direction direction, bool shouldBePlaceable)
        {
            var classUnderTest = new Map(10, 10);
            var result = classUnderTest.TryPlace(Ship.Carrier, (6,6), direction);
            Assert.That(result, Is.EqualTo(shouldBePlaceable));
        }

        [Test]
        public void When_placing_a_ship_that_would_intersect_another_ship()
        {
            var classUnderTest = new Map(10, 10);
            classUnderTest.TryPlace(Ship.Battleship, (0, 3), Direction.East);
            var result = classUnderTest.TryPlace(Ship.Carrier, (0, 0), Direction.North);
            Assert.That(result, Is.False);
        }
    }
}