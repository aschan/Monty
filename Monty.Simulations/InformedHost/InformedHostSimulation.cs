namespace Monty.Simulations.InformedHost
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class InformedHostSimulation : ISimulation
    {
        private readonly Random _randomGenerator = new Random();

        public ISimulationResult Run(int numberOfGames, bool switchDoor)
        {
            var now = DateTimeOffset.UtcNow;
            var games = GenerateGames(numberOfGames);
            var results = games.AsParallel().AsOrdered().Select(g => g.Play(switchDoor)).ToList();

            return new SimulationResult(now, results);
        }

        private IEnumerable<IGame> GenerateGames(int numberOfGames)
        {
            return Enumerable.Range(1, numberOfGames).Select(i => new InformedHostGame(i, _randomGenerator));
        }
    }
}
