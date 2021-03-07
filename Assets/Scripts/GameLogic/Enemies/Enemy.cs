using System;
using Infrastructure.Services;
using Infrastructure.Services.Abstract;
using UnityEngine;

namespace GameLogic.Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _detectionRange = 2f;
        [SerializeField] private float _attackDistance = 0.2f;
        [SerializeField] private float _attackCooldownSec = 1.3f;
        [SerializeField] private float _speed = 50f;
        [SerializeField] private int _hp = 3;

        public event Action<Enemy> OnDeath;
        
        private const int PLAYER_LAYER_MASK = 1 << 8;

        private Vector2 LocalForward => transform.right;
        private CreatureMover _mover;
        private EnemyAnimator _animator;
        private bool _attackCooldownFinished;
        private RaycastHit2D _playerRaycastHit;
        private ITimeService _timeService;
        private Rigidbody2D _rigidBody;
        private bool _isDead;

        public void Construct(ITimeService timeService)
        {
            _timeService = timeService;
        }

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _mover = new CreatureMover(_rigidBody);
            _animator = new EnemyAnimator(GetComponent<Animator>());
            _attackCooldownFinished = true;
            _isDead = false;
        }

        private void Update()
        {
            if(_isDead)
                return;
            
            SearchPlayer();
            ProcessAttack();
            ProcessMovingToPlayer();
        }
        
        public void Damage(int amount)
        {
            _hp -= amount;
            Debug.Log($"Damage {gameObject.name} for {amount} hp");
            if (_hp > 0)
            {
                _animator.GetHit();
            }
            else
            {
                Death();
            }
        }

        private void SearchPlayer()
        {
            _playerRaycastHit = Physics2D.Raycast((Vector2) transform.position + Vector2.left * _detectionRange,
                Vector2.right,
                _detectionRange * 2,
                PLAYER_LAYER_MASK);
        }
        
        private bool IsPlayerFound()
        {
            return _playerRaycastHit.collider != null;
        }

        private void ProcessAttack()
        {
            if (!CanAttack())
                return;
            
            Attack();
        }

        private void Attack()
        {
            _animator.Attack();

            _attackCooldownFinished = false;
            _timeService.StartTimer(_attackCooldownSec, null, () => _attackCooldownFinished = true);
        }

        private bool CanAttack()
        {
            return IsInAttackDistance() && _attackCooldownFinished;
        }

        private bool IsInAttackDistance()
        {
            if (!IsPlayerFound())
                return false;
            
            return Mathf.Abs(_playerRaycastHit.transform.position.x - transform.position.x) <= _attackDistance;
        }

        private void ProcessMovingToPlayer()
        {
            _animator.SetMovementVector(_rigidBody.velocity);
            if (!IsPlayerFound())
                return;

            _mover.Move(_playerRaycastHit.transform.position - transform.position, _speed * Time.deltaTime);
        }

        private void Death()
        {
            _isDead = true;
            _animator.PlayDeathAnimation();
            gameObject.layer = Layers.DeadEnemy;
            OnDeath?.Invoke(this);
            Destroy(gameObject, 5f);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay((Vector2) transform.position + Vector2.left * _detectionRange, Vector2.right * _detectionRange * 2);
        }
    }
}