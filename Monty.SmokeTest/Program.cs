namespace Monty.SmokeTest
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Monty.Simulations.InformedHost;

    internal static class Program
    {
        internal static async Task Main(string[] args)
        {
            //var numberOfGames = int.MaxValue / 65536;
            //var numberOfGames = int.MaxValue / 4096;
            //var numberOfGames = int.MaxValue / 256;
            //var numberOfGames = int.MaxValue / 16;
            //var numberOfGames = int.MaxValue / 4;
            //var numberOfGames = int.MaxValue;
            var numberOfGames = 2;
            await SimulateSwitchingDoorsAsync(numberOfGames).ConfigureAwait(false);
            await SimulateNotSwitchingDoorsAsync(numberOfGames).ConfigureAwait(false);
        }

        internal static async Task SimulateSwitchingDoorsAsync(int numberOfGames)
        {
            var simulation = new InformedHostSimulation();
            var stopwatch = Stopwatch.StartNew();
            var result = await Task.Run(() => simulation.Run(numberOfGames, true)).ConfigureAwait(false);
            Console.WriteLine($"When switching doors the contestant wins {result.WinPercentage} percent of the games.");
            stopwatch.Stop();
            Console.WriteLine($"Simulated {numberOfGames} games in {stopwatch.ElapsedMilliseconds} ms");
        }

        internal static async Task SimulateNotSwitchingDoorsAsync(int numberOfGames)
        {
            var simulation = new InformedHostSimulation();
            var stopwatch = Stopwatch.StartNew();
            var result = await Task.Run(() => simulation.Run(numberOfGames, false)).ConfigureAwait(false);
            Console.WriteLine($"When not switching doors the contestant wins {result.WinPercentage} percent of the games.");
            stopwatch.Stop();
            Console.WriteLine($"Simulated {numberOfGames} games in {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
