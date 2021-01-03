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

        private Vector2 LocalForward => transform.right;
        private CreatureMover _mover;

        private void Awake()
        {
            _mover = new CreatureMover(GetComponent<Rigidbody2D>());
        }

        private void Update()
        {
            var playerHit = IsPlayerDetected();

            if (playerHit.collider == null)
                return;
            
            _mover.RotateDirection(playerHit.transform.position - transform.position);
            _mover.Move(LocalForward, _speed * Time.deltaTime);
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