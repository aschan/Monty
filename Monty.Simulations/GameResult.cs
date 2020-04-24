namespace Monty.Simulations
{
    public class GameResult : IGameResult
    {
        public GameResult(int id, bool won)
        {
            Id = id;
            Won = won;
        }

        public int Id { get; }

        public bool SwitchedDoor { get; }

        public bool Won { get; }
    }
}
