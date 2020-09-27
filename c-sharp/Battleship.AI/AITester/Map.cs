using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Battleship.AI.AITester
{
    public interface ITestMap
    {
        FireResult Shoot((int x, int y) point);
        bool IsWon();
    }

    public class Map : ITestMap
    {
        private int columnCount;
        private int rowCount;

        private readonly Dictionary<Direction, (int x, int y)> directionVectors =
            new Dictionary<Direction, (int x, int y)>
            {
                {Direction.North, (0, 1)},
                {Direction.East, (1, 0)},
                {Direction.South, (0, -1)},
                {Direction.West, (-1, 0)}
            };

        private char[,] map;
        private const char HitMarker = 'X';

        public Map() : this(10, 10)
        {

        }

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
            for (int i = 0; i < shipToAdd.Length; i++)
            {
                allPoints.Add((originPoint.x + (vector.x * i), originPoint.y + (vector.y * i)));
            }

            if (allPoints.All(IsAvailable))
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

        public static Map Deserialize(string serialized)
        {
            var newMap = new Map();
            newMap.map = JsonConvert.DeserializeObject<char[,]>(serialized);
            return newMap;
        }

        public FireResult Shoot((int x, int y) point)
        {
            var locationValue = map[point.x, point.y];
            if (locationValue == '\0')
            {
                return FireResult.Miss;
            }

            map[point.x, point.y] = HitMarker;

            return MapContains(locationValue) ? FireResult.Hit : FireResult.Sink;
        }

        private bool MapContains(char marker)
        {
            for (var x = 0; x < columnCount; x++)
            {
                for (var y = 0; y < rowCount; y++)
                {
                    if (map[x, y] == marker)
                        return true;
                }
            }

            return false;
        }

        public bool IsWon()
        {
            for (var x = 0; x < columnCount; x++)
            {
                for (var y = 0; y < rowCount; y++)
                {
                    if (!(HasBeenShotOrIsMiss(map[x, y])))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool HasBeenShotOrIsMiss(char locationValue)
        {
            return locationValue == HitMarker || locationValue == '\0';
        }
    }
}
