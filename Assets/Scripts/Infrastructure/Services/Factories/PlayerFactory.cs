using System;
using GameLogic.Player;
using Infrastructure.Services.Abstract.Factories;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.Services.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public event Action<Player> OnPlayerCreated;

        public Player Player { get; private set; }
        
        public Player CreatePlayer()
        {            
            var playerPrefab = Resources.Load<Player>(AssetsPath.Player);
            
            Player = Object.Instantiate(playerPrefab);
            OnPlayerCreated?.Invoke(Player);
            return Player;
        }
    }
}