using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace MapGenerator 
{
    public class Map
    {
        private int columnCount;
        private int rowCount;

        private readonly Dictionary<Direction, (int x, int y)> directionVectors = new Dictionary<Direction, (int x, int y)>
        {
            {Direction.North, (0, 1)},
            {Direction.East, (1, 0)},
            {Direction.South, (0, -1)},
            {Direction.West, (-1, 0)}
        };

        private char[,] map;

        public Map(int columnCount, int rowCount)
        {
            this.columnCount = columnCount;
            this.rowCount = rowCount;
            map = new char[columnCount, rowCount];
        }

        public bool TryPlace(Ship shipToAdd, (int x, int y) originPoint, Direction direction)
        {
            var vector = directionVectors[direction];
            var allPoints = new List<(int, int)>();
            for(int i = 0; i < shipToAdd.Length; i ++)
            {
                allPoints.Add((originPoint.x + (vector.x * i), originPoint.y + (vector.y * i)));
            }
            if(allPoints.All(IsAvailable))
            {
                allPoints.ForEach(x => WriteShipToPoint(shipToAdd, x));
                return true;
            }
            return false;
        }

        private void WriteShipToPoint(Ship shipToAdd, (int x, int y) point)
        {
            map[point.x, point.y] = shipToAdd.Marker;
        }

        private bool IsAvailable((int x, int y) point)
        {
            return IsValidLocation(point) && map[point.x, point.y] == '\0';
        }

        private bool IsValidLocation((int x, int y) point)
        {
            return (point.x >= 0 && point.x < columnCount) && (point.y >= 0 && point.y < columnCount);
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(map);
        }
    }
}