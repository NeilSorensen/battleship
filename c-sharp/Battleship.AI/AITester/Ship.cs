namespace Battleship.AI.AITester
{

    public class Ship 
    {
        private Ship(int length, char marker) 
        {
            Length = length;
            Marker = marker;
        }

        public int Length { get; }

        public char Marker { get; }

        public static readonly Ship Carrier = new Ship(5, 'C');
        public static readonly Ship Battleship = new Ship(4, 'B');
        public static readonly Ship Cruiser = new Ship(3, 'c');
        public static readonly Ship Submarine = new Ship(3, 'S');
        public static readonly Ship Destroyer = new Ship(2, 'D');    
    }
}
