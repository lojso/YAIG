using System;
using GameLogic.Player;

namespace Infrastructure.Services.Abstract.Factories
{
    public interface IPlayerFactory : IService
    {
        event Action<Player> OnPlayerCreated;
        
        Player Player { get; }

        Player CreatePlayer();
    }
}