using System;
using GameLogic.Player;
using Infrastructure.Services.Abstract;
using Infrastructure.Services.Abstract.Factories;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.Services.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly IInputService _inputService;
        private readonly ITimeService _timeService;

        public PlayerFactory(IInputService inputService, ITimeService timeService)
        {
            _inputService = inputService;
            _timeService = timeService;
        }

        public event Action<Player> OnPlayerCreated;

        public Player Player { get; private set; }
        
        public Player CreatePlayer()
        {            
            var playerPrefab = Resources.Load<Player>(AssetsPath.Player);
            
            Player = Object.Instantiate(playerPrefab);
            Player.Construct(_inputService, _timeService);
            OnPlayerCreated?.Invoke(Player);
            return Player;
        }
    }
}