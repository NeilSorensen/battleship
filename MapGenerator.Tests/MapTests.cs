using NUnit.Framework;

namespace MapGenerator.Tests
{
    public class ShipPlacementCheckerTests
    {
        [TestCase(Direction.North, false)]
        public void When_placing_a_ship_at_0_0_on_an_empty_map(Direction direction, bool shouldBePlaceable)
        {
            var classUnderTest = new Map(10, 10);
            var result = classUnderTest.TryPlace(5, (0,0), direction);
            Assert.That(result, Is.EqualTo(shouldBePlaceable));
        }
    }
}