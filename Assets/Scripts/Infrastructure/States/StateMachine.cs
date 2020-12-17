using System;
using System.Collections.Generic;
using Infrastructure.Services;
using Infrastructure.Services.Abstract;

namespace Infrastructure.States
{
    public class StateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public StateMachine(ServicesContainer services)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, services),
                [typeof(LoadLevelState)] = new LoadLevelState(this, services.Single<ISceneLoader>()),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }
    
        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TContext>(TContext context) where TState : class, IState<TContext>
        {
            IState<TContext> state = ChangeState<TState>();
            state.Enter(context);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState => 
            _states[typeof(TState)] as TState;
    }
}