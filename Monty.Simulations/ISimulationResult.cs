namespace Monty.Simulations
{
    using System;
    using System.Collections.Generic;

    public interface ISimulationResult
    {
        int NumberOfGames { get; }

        bool SwitchDoor { get;  }

        decimal WinPercentage { get; }

        DateTimeOffset ExecutionDate { get; }

        IEnumerable<IGameResult> GameResults { get; }
    }
}
