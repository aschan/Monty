namespace Monty.Simulations
{
    public interface IGameResult
    {
        int Id { get; }

        bool SwitchedDoor { get; }

        bool Won { get; }
    }
}
