using System;
using Infrastructure.Services;
using Infrastructure.Services.Abstract;
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
            var runtimeService = new GameObject("RuntimeService").AddComponent<RuntimeService>();
            _services.RegisterSingle<IRuntimeService>(runtimeService);
            _services.RegisterSingle<IInputService>(new InputService());
            _services.RegisterSingle<IEnemyFactory>(new EnemyFactory());
            _services.RegisterSingle<ISceneLoader>(new SceneLoader(_services.Single<IRuntimeService>()));
        }
    }
}