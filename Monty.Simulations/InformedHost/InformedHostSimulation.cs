namespace Monty.Simulations.InformedHost
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public class InformedHostSimulation : ISimulation
    {
        public ISimulationResult Run(int numberOfGames, bool switchDoor)
        {
            var now = DateTimeOffset.UtcNow;
            var games = GenerateGames(numberOfGames);
            var results = games.AsParallel().Select(g => g.Play(switchDoor)).ToList();

            return new SimulationResult(now, switchDoor, results);
        }

        private IEnumerable<IGame> GenerateGames(int numberOfGames)
        {
            using (var random = new ThreadLocal<Random>(() => new Random(Guid.NewGuid().GetHashCode())))
            {
                return Enumerable.Range(1, numberOfGames)
                                 .AsParallel()
                                 .Select(i => new InformedHostGame(i, random))
                                 .ToList();
            }
        }
    }
}
