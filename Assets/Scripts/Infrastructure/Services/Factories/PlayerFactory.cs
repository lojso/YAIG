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
        private readonly IFrameShakeService _frameShakeService;
        private readonly ICameraShakeService _cameraShakeService;

        public PlayerFactory(IInputService inputService, ITimeService timeService, IFrameShakeService frameShakeService, ICameraShakeService cameraShakeService)
        {
            _inputService = inputService;
            _timeService = timeService;
            _frameShakeService = frameShakeService;
            _cameraShakeService = cameraShakeService;
        }

        public event Action<Player> OnPlayerCreated;

        public Player Player { get; private set; }
        
        public Player CreatePlayer()
        {            
            var playerPrefab = Resources.Load<Player>(AssetsPath.Player);
            
            Player = Object.Instantiate(playerPrefab);
            Player.Construct(_inputService, _timeService, _frameShakeService, _cameraShakeService);
            OnPlayerCreated?.Invoke(Player);
            return Player;
        }
    }
}