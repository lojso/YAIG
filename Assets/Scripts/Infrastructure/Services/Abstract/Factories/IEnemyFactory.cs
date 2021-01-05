using UnityEngine;

namespace Infrastructure.Services.Abstract.Factories
{
    public interface IEnemyFactory : IService
    {
        GameObject SpawnEnemy();
    }
}