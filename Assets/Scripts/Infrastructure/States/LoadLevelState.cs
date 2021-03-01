using Infrastructure.Services.Abstract;
using Infrastructure.Services.Abstract.Factories;
using UnityEngine;

namespace Infrastructure.States
{
    public class LoadLevelState : IState<string>
    {
        private readonly StateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ICameraFactory _cameraFactory;
        private readonly IPlayerFactory _playerFactory;
        private readonly IUiFactory _uiFactory;
        private readonly IFrameShakeService _frameShakeService;

        public LoadLevelState(StateMachine stateMachine, ISceneLoader sceneLoader, ICameraFactory cameraFactory,
            IPlayerFactory playerFactory, IUiFactory uiFactory, IFrameShakeService frameShakeService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _cameraFactory = cameraFactory;
            _playerFactory = playerFactory;
            _uiFactory = uiFactory;
            _frameShakeService = frameShakeService;
        }

        public void Enter(string levelName)
        {
            _sceneLoader.Load(levelName, OnLoad);
        }

        public void Exit()
        {
        }

        private void OnLoad()
        {
            // TODO: инициализация уровня
            var player = _playerFactory.CreatePlayer();
            player.transform.position = new Vector3(4.5f, 1.5f, 0f);

            var camera = _cameraFactory.CreateCamera();
            var ui = _uiFactory.CreateUi();
            
            _frameShakeService.SetUiTransform(ui.transform);
            
            _stateMachine.Enter<GameLoopState>();
        }
    }
}