using UnityEngine;

namespace GameLogic.Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _detectionRange = 2f;
        [SerializeField] private float _speed = 50f;
        [SerializeField] private int _hp = 3;
        
        private const int PLAYER_LAYER_MASK = 1 << 8;
        private readonly Quaternion _defaultPosition = Quaternion.Euler(0, 0, 0);
        private readonly Quaternion _invertedPosition = Quaternion.Euler(0, 180, 0);
        
        private Rigidbody2D _rigidBody;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            var playerHit = IsPlayerDetected();

            if (playerHit.collider == null)
                return;
            
            Move(to: playerHit.point);
        }

        public void Damage(int amount)
        {
            _hp -= amount;
            Debug.Log($"Damage {gameObject.name} for {amount} hp");
            if (_hp <= 0)
                Death();
        }

        private void Death()
        {
            Destroy(gameObject);
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

        private void RotateToRight() => 
            transform.rotation = _defaultPosition;

        private void RotateToLeft() => 
            transform.rotation = _invertedPosition;

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

        private RaycastHit2D IsPlayerDetected()
        {
            RaycastHit2D raycastToPlayer;
            
            raycastToPlayer = Physics2D.Raycast((Vector2) transform.position + Vector2.left * _detectionRange,
                Vector2.right,
                _detectionRange * 2,
                PLAYER_LAYER_MASK);
            
            return raycastToPlayer;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay((Vector2) transform.position + Vector2.left * _detectionRange, Vector2.right * _detectionRange * 2);
        }
    }
}