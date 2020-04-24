namespace Monty.SmokeTest
{
    using Monty.Simulations;
    using Monty.Simulations.InformedHost;
    using System;

    internal static class Program
    {
        internal static void Main(string[] args)
        {
            var numberOfGames = 1000;
            var switchingDoorsResult = SimulateSwitchingDoors(numberOfGames);
            var notSwitchingDoorsResult = SimulateNotSwitchingDoors(numberOfGames);

            Console.WriteLine($"When switching doors the contestant wins {switchingDoorsResult.WinPercentage} percent of the games.");
            Console.WriteLine($"When not switching doors the contestant wins {notSwitchingDoorsResult.WinPercentage} percent of the games.");
        }

        internal static ISimulationResult SimulateSwitchingDoors(int numberOfGames)
        {
            var simulation = new InformedHostSimulation();
            return simulation.Run(numberOfGames, true);
        }

        internal static ISimulationResult SimulateNotSwitchingDoors(int numberOfGames)
        {
            var simulation = new InformedHostSimulation();
            return simulation.Run(numberOfGames, false);
        }
    }
}
