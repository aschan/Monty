namespace Monty.Simulations
{
    public class GameResult : IGameResult
    {
        public GameResult(int id, bool win)
        {
            Id = id;
            Win = win;
        }

        public int Id { get; }

        public bool Win { get; }
    }
}
