using System;
using GameLogic.Enemies;
using UnityEngine;

namespace GameLogic.Player
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerHitbox : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.Damage(_damage);
            }
        }
    }
}