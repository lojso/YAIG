using Infrastructure.Services.Abstract;
using UnityEngine;

namespace Infrastructure.Services
{
    public class EnemyFactory : IEnemyFactory
    {
        public GameObject SpawnEnemy()
        {
            var enemyPrefab = Resources.Load<GameObject>(AssetsPath.EnemyPath);
            return Object.Instantiate(enemyPrefab);
        }
    }
}