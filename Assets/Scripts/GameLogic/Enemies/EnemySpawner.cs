using Infrastructure.Services.Abstract;
using Infrastructure.Services.Abstract.Factories;
using UnityEngine;

namespace GameLogic.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy enemyPrefab;
        
        private IEnemyFactory _factory;
        private ITimeService _timeService;

        public void Construct(IEnemyFactory enemyFactory, ITimeService timeService)
        {
            _factory = enemyFactory;
            _timeService = timeService;
        }

        public Enemy CreateEnemy()
        {
            var enemy = _factory.SpawnEnemy().GetComponent<Enemy>();
            enemy.transform.position = transform.position;
            enemy.Construct(_timeService);
            return enemy;
        }
    }
}