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
            _services.RegisterSingle<IAnimationClipsService>(new AnimationClipService(_services.Single<IAnimationFactory>()));
            RegisterShakeServices();
        }

        private void RegisterShakeServices()
        {
            _services.RegisterSingle<ICameraShakeService>(new CameraShakeService(
                _services.Single<ICameraFactory>(),
                _services.Single<IRuntimeService>()));
            _services.RegisterSingle<IFrameShakeService>(new FrameShakeService(
                _services.Single<IUiFactory>(),
                _services.Single<IRuntimeService>()));
        }

        private void RegisterFactories()
        {
            _services.RegisterSingle<IEnemyFactory>(new EnemyFactory());
            _services.RegisterSingle<ICameraFactory>(new CameraFactory());
            _services.RegisterSingle<IPlayerFactory>(new PlayerFactory());
            _services.RegisterSingle<IUiFactory>(new UiFactory());
            _services.RegisterSingle<IAnimationFactory>(new AnimationFactory(_services.Single<IUiFactory>()));
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