namespace Monty.AzureFunctions.Models
{
    using System;

    public interface ISimulationResponse
    {
        DateTimeOffset ExecutionDate { get; }

        int NumberOfGames { get; }

        bool SwitchDoor { get; }

        decimal WinPercentage { get; }
    }
}
