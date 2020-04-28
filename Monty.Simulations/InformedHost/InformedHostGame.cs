namespace Monty.Simulations.InformedHost
{
    using System;
    using System.Threading;

    public class InformedHostGame : IGame
    {
        private readonly int _luckyDoor;
        private readonly int _selectedDoor;

        public InformedHostGame(int id, ThreadLocal<Random> randomGenerator)
        {
            if (id <= 0)
            {
                throw new ArgumentException(@"Value must be a positive integer", nameof(id));
            }
            
            if (randomGenerator == null)
            {
                throw new ArgumentNullException(nameof(randomGenerator));
            }

            if (randomGenerator.Value == null)
            {
                throw new ArgumentException(@"Value must be initialized", nameof(randomGenerator));
            }

            Id = id;
            _luckyDoor = randomGenerator.Value.Next(1, 4);
            _selectedDoor = randomGenerator.Value.Next(1, 4);
        }

        public int Id { get; }

        public IGameResult Play(bool switchDoor)
        {
            Console.WriteLine($"Game {Id}, swith door = {switchDoor}");
            var result = (_selectedDoor == _luckyDoor && !switchDoor) || (_selectedDoor != _luckyDoor && switchDoor);
                
            return new GameResult(Id, switchDoor, result);
        }
    }
}
