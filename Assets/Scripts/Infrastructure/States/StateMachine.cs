using System;
using System.Collections.Generic;
using Infrastructure.Services;

namespace Infrastructure.States
{
    public class StateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public StateMachine()
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, ServicesContainer.Instance),
                [typeof(LoadLevelState)] = new LoadLevelState(this),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }
    
        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TContext>(TContext context) where TState : class, IContextState<TContext>
        {
            IContextState<TContext> state = ChangeState<TState>();
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