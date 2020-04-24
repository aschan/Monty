namespace Monty.Simulations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SimulationResult : ISimulationResult
    {
        public SimulationResult(DateTimeOffset executionDate, IEnumerable<IGameResult> results)
        {
            ExecutionDate = executionDate;
            GameResults = results ?? throw new ArgumentNullException(nameof(results));
        }
 
        public int NumberOfGames => GameResults.Count();

        public decimal WinPercentage => GameResults.Count(r => r.Win) / (decimal)NumberOfGames;

        public DateTimeOffset ExecutionDate { get; }

        public IEnumerable<IGameResult> GameResults { get; }
    }
}
