namespace Monty.Simulations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SimulationResult : ISimulationResult
    {
        public SimulationResult(DateTimeOffset executionDate, bool switchDoor, IEnumerable<IGameResult> results)
        {
            ExecutionDate = executionDate;
            SwitchDoor = switchDoor;
            GameResults = results ?? throw new ArgumentNullException(nameof(results));
        }
 
        public int NumberOfGames => GameResults.Count();

        public bool SwitchDoor { get; }

        public decimal WinPercentage => 100 * (GameResults.Count(r => r.Won) / (decimal)NumberOfGames);

        public DateTimeOffset ExecutionDate { get; }

        public IEnumerable<IGameResult> GameResults { get; }
    }
}
