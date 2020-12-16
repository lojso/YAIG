using Infrastructure.States;

namespace Infrastructure
{
    public class Game
    {
        private readonly StateMachine _stateMachine;

        public Game()
        {
            _stateMachine = new StateMachine();
        }
    }
}