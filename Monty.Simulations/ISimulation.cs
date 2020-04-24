namespace Monty.Simulations
{
    public interface ISimulation
    {
        ISimulationResult Run(int numberOfGames, bool switchDoor);
    }
}
