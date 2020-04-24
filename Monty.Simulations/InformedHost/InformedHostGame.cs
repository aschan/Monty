namespace Monty.Simulations.InformedHost
{
    using System;

    public class InformedHostGame : IGame
    {
        private readonly Random _randomGenerator;

        public InformedHostGame(int id, Random randomGenerator)
        {
            Id = id;
            _randomGenerator = randomGenerator ?? throw new ArgumentNullException(nameof(randomGenerator));
        }

        public int Id { get; }

        public IGameResult Play(bool switchDoor)
        {
            var luckyDoor = _randomGenerator.Next(1, 4);
            var selectedDoor = _randomGenerator.Next(1, 4);

            return new GameResult(Id, !(selectedDoor == luckyDoor && switchDoor));
        }
    }
}
