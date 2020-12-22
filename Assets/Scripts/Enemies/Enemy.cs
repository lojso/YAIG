using System;
using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _detectionRange;

        private const int PLAYER_LAYER_MASK = 1 << 8;

        private void Update()
        {
            var playerHit = IsPlayerDetected();
            if(playerHit.collider != null)
                Debug.Log("Found u!");
        }

        private RaycastHit2D IsPlayerDetected()
        {
            RaycastHit2D raycastToPlayer; 
            raycastToPlayer = Physics2D.Raycast(transform.position, Vector2.right, _detectionRange, PLAYER_LAYER_MASK);
            if (raycastToPlayer.collider != null)
                return raycastToPlayer;

            raycastToPlayer = Physics2D.Raycast(transform.position, Vector2.left, _detectionRange, PLAYER_LAYER_MASK);
            // TODO: это все можно сделать одним рейкастом
            return raycastToPlayer;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, Vector2.left * _detectionRange);
            Gizmos.DrawRay(transform.position, Vector2.right * _detectionRange);
        }
    }
}