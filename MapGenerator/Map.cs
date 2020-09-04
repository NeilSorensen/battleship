using System;

namespace MapGenerator 
{
    public class Map
    {
        private int columnCount;
        private int rowCount;

        public Map(int columnCount, int rowCount)
        {
            this.columnCount = columnCount;
            this.rowCount = rowCount;
        }

        public bool TryPlace(int shipLength, (int, int) originPoint, Direction direction)
        {
            return false;
        }
    }
}