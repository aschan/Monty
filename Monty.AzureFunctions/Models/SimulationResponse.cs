namespace Monty.AzureFunctions.Models
{
    using System;

    using Monty.Simulations;

    public class SimulationResponse : ISimulationResponse
    {
        public SimulationResponse(ISimulationResult result)
        {
            if (result==null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            ExecutionDate = result.ExecutionDate;
            NumberOfGames = result.NumberOfGames;
            SwitchDoor = result.SwitchDoor;
            WinPercentage = result.WinPercentage;
        }

        public DateTimeOffset ExecutionDate { get; }

        public int NumberOfGames { get; }

        public bool SwitchDoor { get; }

        public decimal WinPercentage { get; }
    }
}
