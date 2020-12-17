using Infrastructure.Services;
using Infrastructure.States;

namespace Infrastructure
{
    public class Game
    {
        public readonly StateMachine StateMachine;

        public Game()
        {
            StateMachine = new StateMachine(ServicesContainer.Instance);
        }
    }
}