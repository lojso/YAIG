using Infrastructure.Services.Abstract;
using Infrastructure.Services.Abstract.Factories;
using UnityEngine;

namespace GameLogic.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy enemyPrefab;
        
        private IEnemyFactory _factory;
        private IAnimationClipsService _animationClips;
        private ITimeService _timeService;

        public void Construct(IEnemyFactory enemyFactory, IAnimationClipsService animationClipsService,
            ITimeService timeService)
        {
            _factory = enemyFactory;
            _animationClips = animationClipsService;
            _timeService = timeService;
        }

        public Enemy CreateEnemy()
        {
            var enemy = _factory.SpawnEnemy().GetComponent<Enemy>();
            enemy.transform.position = transform.position;
            enemy.Construct(_timeService, _animationClips);
            return enemy;
        }
    }
}