using GameLogic.Enemies;
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
        private readonly IEnemyFactory _enemyFactory;
        private readonly ITimeService _timeService;
        private readonly IAnimationClipsService _animationClipsService;

        public LoadLevelState(StateMachine stateMachine, ISceneLoader sceneLoader, ICameraFactory cameraFactory,
            IPlayerFactory playerFactory, IUiFactory uiFactory, IFrameShakeService frameShakeService,
            IEnemyFactory enemyFactory, ITimeService timeService, IAnimationClipsService _animationClipsService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _cameraFactory = cameraFactory;
            _playerFactory = playerFactory;
            _uiFactory = uiFactory;
            _frameShakeService = frameShakeService;
            _enemyFactory = enemyFactory;
            _timeService = timeService;
            this._animationClipsService = _animationClipsService;
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
            InitializeUi();
            
            InitializePlayer();

            InitializeEnemies();

            _stateMachine.Enter<GameLoopState>();
        }

        private void InitializeEnemies()
        {
            var spawners = Object.FindObjectsOfType<EnemySpawner>();
            
            foreach (var spawner in spawners)
            {
                spawner.Construct(_enemyFactory, _animationClipsService, _timeService);
                spawner.CreateEnemy();
            }
        }

        private void InitializePlayer()
        {
            var player = _playerFactory.CreatePlayer();
            player.transform.position = new Vector3(4.5f, 1.5f, 0f);
        }

        private void InitializeUi()
        {
            var camera = _cameraFactory.CreateCamera();
            var ui = _uiFactory.CreateUi();
            _frameShakeService.SetUiTransform(ui.Frame.transform);
        }
    }
}