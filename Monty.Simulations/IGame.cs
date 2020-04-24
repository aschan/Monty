﻿namespace Monty.Simulations
{
    public interface IGame
    {
        int Id { get; }

        IGameResult Play(bool switchDoor);
    }
}
