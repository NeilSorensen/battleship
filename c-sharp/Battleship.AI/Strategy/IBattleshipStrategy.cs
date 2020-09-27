using Battleship.AI.AITester;

namespace Battleship.AI.Strategy
{
    public interface IBattleshipStrategy
    {
        public (int x, int y) GetNextMove(FireResult lastResult);
    }
}
