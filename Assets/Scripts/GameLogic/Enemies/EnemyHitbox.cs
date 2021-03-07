using UnityEngine;

namespace GameLogic.Enemies
{
    [RequireComponent(typeof(Collider2D))]
    public class EnemyHitbox : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Player.Player>(out var player))
            {
                player.Damage(new PlayerDamageInfo()
                {
                    Damage = _damage,
                    ShakeType = ShakeType.Random,
                });
            }
        }
    }

    public class PlayerDamageInfo
    {
        public int Damage;
        public ShakeType ShakeType;
    }

    public enum ShakeType
    {
        Unknown,
        Camera,
        Frame,
        Random
    }
}