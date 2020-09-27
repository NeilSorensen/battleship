using System.Text.RegularExpressions;
using NUnit.Framework;

namespace MapGenerator.Tests
{
    public class BattleshipPlacerTests
    {
        private BattleshipPlacer classUnderTest;
        private Map generatedMap;
        private string serializedMap;

        [OneTimeSetUp]
        public void Setup()
        {
            classUnderTest = new BattleshipPlacer();
            generatedMap = classUnderTest.GenerateMap();
            serializedMap = generatedMap.Serialize();
        }

        [Test]
        public void Generated_map_should_have_the_carrier()
        {
            ShipShouldBePresent(Ship.Carrier);
        }

        [Test]
        public void Generated_map_should_have_the_battleship()
        {
            ShipShouldBePresent(Ship.Battleship);
        }

        [Test]
        public void Generated_map_should_have_the_cruiser()
        {
            ShipShouldBePresent(Ship.Cruiser);
        }

        [Test]
        public void Generated_map_should_have_the_submarine()
        {
            ShipShouldBePresent(Ship.Submarine);
        }

        [Test]
        public void Generated_map_should_have_the_destroyer()
        {
            ShipShouldBePresent(Ship.Destroyer);
        }

        [Test]
        public void GeneratedMapsShouldBeDifferent()
        {
            var nextMap = classUnderTest.GenerateMap();
            Assert.That(nextMap.Serialize(), Is.Not.EqualTo(serializedMap));
        }

        private void ShipShouldBePresent(Ship shipToCheck)
        {
            var pattern = $"\\\"{shipToCheck.Marker}\\\"";
            var matches = Regex.Matches(serializedMap, pattern);
            Assert.That(matches.Count, Is.EqualTo(shipToCheck.Length));
        }
    }
}