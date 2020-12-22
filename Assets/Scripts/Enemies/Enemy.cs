using System;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _detectionRange = 2f;
        [SerializeField] private float _speed = 50f;
        
        private const int PLAYER_LAYER_MASK = 1 << 8;
        private readonly Quaternion _defaultPosition = Quaternion.Euler(0, 0, 0);
        private readonly Quaternion _invertedPosition = Quaternion.Euler(0, 180, 0);
        
        private Rigidbody2D _rigidBody;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            var playerHit = IsPlayerDetected();

            if (playerHit.collider == null)
                return;
            
            Move(to: playerHit.point);
        }

        private void Move(Vector2 to)
        {
            Rotate(to);
            MoveForward(transform.right, _speed);
        }

        private void Rotate(Vector2 to)
        {
            if(to.x < transform.position.x)
            {
                RotateToLeft();
            }
            else
            {
                RotateToRight();
            }
        }

        private void MoveForward(Vector2 direction, float speed)
        {
            var velocity = _rigidBody.velocity;
            velocity.x = direction.x * _speed * Time.fixedDeltaTime;
            _rigidBody.velocity = velocity;
        }

        private void Stop()
        {
            _rigidBody.velocity = Vector2.zero;
        }

        private void RotateToRight() => 
            transform.rotation = _defaultPosition;
        
        private void RotateToLeft() => 
            transform.rotation = _invertedPosition;

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