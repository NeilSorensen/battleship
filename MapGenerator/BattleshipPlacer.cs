using System;
using System.Collections.Generic;

namespace MapGenerator
{
    public class BattleshipPlacer 
    {
        private const int MaxColumns = 10;
        private const int MaxRows = 10;
        private List<Ship> allShips = new List<Ship>{Ship.Carrier, Ship.Battleship, Ship.Cruiser, Ship.Submarine, Ship.Destroyer};
        private Random random = new Random();
        public Map GenerateMap()
        {
            var map = new Map(MaxColumns, MaxRows);

            foreach(var ship in allShips)
            {
                (int, int) randomPoint;
                Direction randomHeading;
                do
                {
                    randomPoint = (random.Next(MaxColumns), random.Next(MaxRows));
                    randomHeading = (Direction)random.Next(4);
                }while(!map.TryPlace(ship, randomPoint, randomHeading));
            }

            return map;
        }

    }
}