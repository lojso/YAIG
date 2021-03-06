using GameLogic.Enemies;
using Infrastructure.Services.Abstract;

namespace GameLogic
{
    public class PopupClipsController
    {
        private readonly IAnimationPopupClipsService _animationPopupClipsService;

        public PopupClipsController(IAnimationPopupClipsService animationPopupClipsService)
        {
            _animationPopupClipsService = animationPopupClipsService;
        }

        public void RegisterEnemy(Enemy enemy)
        {
            enemy.OnDeath += EnemyDeathHandler;
        }

        private void EnemyDeathHandler(Enemy enemy)
        {
            enemy.OnDeath -= EnemyDeathHandler;
            
            _animationPopupClipsService.PlayTestAnimation();
        }
    }
}