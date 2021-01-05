using Infrastructure.Services.Abstract.Factories;
using UnityEngine;

namespace Infrastructure.Services.Factories
{
    public class EnemyFactory : IEnemyFactory
    {
        public GameObject SpawnEnemy()
        {
            var enemyPrefab = Resources.Load<GameObject>(AssetsPath.Enemy);
            return Object.Instantiate(enemyPrefab);
        }
    }
}