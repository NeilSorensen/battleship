using Battleship.AI.AITester;

namespace Battleship.AI.Strategy
{
    public class NaiveBattleshipStrategy : IBattleshipStrategy
    {
        private int targetX;
        private int targetY;
        private const int MaxColumns = 10;

        public NaiveBattleshipStrategy()
        {

        }

        public (int x, int y) GetNextMove(FireResult lastResult)
        {
            if (lastResult == FireResult.None)
            {
                targetX = 0;
                targetY = 0;
            }
            else
            {
                targetX++;
                if (targetX >= MaxColumns)
                {
                    targetX = 0;
                    targetY++;
                }
            }

            return (targetX, targetY);
        }
    }
}
