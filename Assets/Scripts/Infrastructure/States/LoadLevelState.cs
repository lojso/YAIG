using System;
using Infrastructure.Services.Abstract;

namespace Infrastructure.States
{
    public class LoadLevelState : IState<string>
    {
        private readonly StateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;

        public LoadLevelState(StateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string levelName)
        {
            //TODO: сюда можно впихнуть экран загрузки
            _sceneLoader.Load(levelName, OnLoad);
        }

        public void Exit()
        {
        }

        private void OnLoad()
        {
            // TODO: инициализация уровня
            _stateMachine.Enter<GameLoopState>();
        }
    }
}