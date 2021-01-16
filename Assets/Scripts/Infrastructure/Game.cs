using GameLogic.Player;
using Infrastructure.Services;
using Infrastructure.Services.Abstract.Factories;
using Infrastructure.States;
using UnityEngine;

namespace Infrastructure
{
    public class Game
    {
        public readonly StateMachine StateMachine;

        private Player _player;

        public Game()
        {
            StateMachine = new StateMachine(ServicesContainer.Instance);

            ServicesContainer.Instance.Single<IPlayerFactory>().OnPlayerCreated += PlayerCreationHandle;
        }

        private void PlayerCreationHandle(Player player)
        {
            _player = player;
            player.OnDeath += PlayerDeathHandler;
        }

        private void PlayerDeathHandler(Player player)
        {
            player.OnDeath -= PlayerDeathHandler;
            StateMachine.Enter<LoadLevelState, string>("GameScene");
        }
    }
}