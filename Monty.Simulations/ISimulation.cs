namespace Monty.Simulations
{
    using System.Collections.Generic;

    public interface ISimulation
    {
        IEnumerable<IResult> Run(int numberOfGames, bool switchDoor);
    }
}
