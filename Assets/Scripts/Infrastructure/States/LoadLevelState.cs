using System;

namespace Infrastructure.States
{
    public class LoadLevelState : IContextState<string>
    {
        public LoadLevelState(StateMachine stateMachine)
        {
        }

        public void Enter(string context)
        {
        }

        public void Exit()
        {
        }
    }
}