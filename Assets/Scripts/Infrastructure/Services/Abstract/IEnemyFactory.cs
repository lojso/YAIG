using UnityEngine;

namespace Infrastructure.Services.Abstract
{
    public interface IEnemyFactory : IService
    {
        GameObject SpawnEnemy();
    }
}