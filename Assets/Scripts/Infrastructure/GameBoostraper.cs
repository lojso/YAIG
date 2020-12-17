using Infrastructure.States;
using UnityEngine;

namespace Infrastructure
{
    public class GameBoostraper : MonoBehaviour
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game();
            
            _game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}