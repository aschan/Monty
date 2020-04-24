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
            var results = games.Select(g => g.Play(switchDoor));

            return new SimulationResult(now, switchDoor, results);
        }

        private IEnumerable<IGame> GenerateGames(int numberOfGames)
        {
            foreach (var id in Enumerable.Range(1, numberOfGames))
            {
                yield return new InformedHostGame(id, _randomGenerator);
            }
        }
    }
}
