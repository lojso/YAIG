using Infrastructure.Services;
using Infrastructure.Services.Abstract;
using UnityEngine;

namespace GameLogic.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [Tooltip("Через сколько секунд начинается спавн противника")] [SerializeField]
        private float _spawnTime = 1f;

        private IEnemyFactory _factory;
        private float _spawnCooldown;

        private void Awake()
        {
            _factory = ServicesContainer.Instance.Single<IEnemyFactory>();
            _spawnCooldown = _spawnTime;
        }

        private void FixedUpdate()
        {
            if (_spawnCooldown <= 0)
            {
                var enemy = _factory.SpawnEnemy();
                enemy.transform.position = transform.position;

                _spawnCooldown = _spawnTime;
            }
            else
            {
                _spawnCooldown -= Time.fixedDeltaTime;
            }
        }
    }
}