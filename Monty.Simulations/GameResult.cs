namespace Monty.Simulations
{
    public class GameResult : IGameResult
    {
        public GameResult(int id, bool switchedDoor, bool won)
        {
            Id = id;
            SwitchedDoor = switchedDoor;
            Won = won;
        }

        public int Id { get; }

        public bool SwitchedDoor { get; }

        public bool Won { get; }
    }
}
