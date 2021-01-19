﻿using Infrastructure.Services;
using Infrastructure.Services.Abstract;
using Infrastructure.Services.Abstract.Factories;
using Infrastructure.Services.Factories;
using UnityEngine;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string InitialSceneName = "InitialScene";
        private const string GameSceneName = "GameScene";
        private readonly StateMachine _stateMachine;
        private readonly ServicesContainer _services;

        public BootstrapState(StateMachine stateMachine, ServicesContainer services)
        {
            _stateMachine = stateMachine;
            _services = services;

            RegisterServices();
        }

        public void Enter()
        {
            _services.Single<ISceneLoader>().Load(InitialSceneName, EnterLoadLevelState);
        }

        private void EnterLoadLevelState()
        {
            _stateMachine.Enter<LoadLevelState, string>(GameSceneName);
        }

        public void Exit()
        {
        }

        private void RegisterServices()
        {
            RegisterRuntimeService();
            RegisterTimeService();
            RegisterFactories();
            _services.RegisterSingle<IInputService>(new InputService());
            _services.RegisterSingle<ISceneLoader>(new SceneLoader(_services.Single<IRuntimeService>()));
           // _services.RegisterSingle<IAnimationClipsService>(new ANimation);
        }

        private void RegisterFactories()
        {
            _services.RegisterSingle<IEnemyFactory>(new EnemyFactory());
            _services.RegisterSingle<ICameraFactory>(new CameraFactory());
            _services.RegisterSingle<IPlayerFactory>(new PlayerFactory());
        }

        private void RegisterRuntimeService()
        {
            var runtimeService = new GameObject("RuntimeService").AddComponent<RuntimeService>();
            _services.RegisterSingle<IRuntimeService>(runtimeService);
        }
        
        private void RegisterTimeService()
        {
            var timeService = new GameObject("TimeService").AddComponent<TimeService>();
            _services.RegisterSingle<ITimeService>(timeService);
        }
    }
}