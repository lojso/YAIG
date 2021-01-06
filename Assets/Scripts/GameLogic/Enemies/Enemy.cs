using Infrastructure.Services;
using Infrastructure.Services.Abstract;
using UnityEditorInternal;
using UnityEngine;

namespace GameLogic.Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _detectionRange = 2f;
        [SerializeField] private float _attackDistance = 0.1f;
        [SerializeField] private float _attackCooldownSec = 1.3f;
        [SerializeField] private float _speed = 50f;
        [SerializeField] private int _hp = 3;
        
        private const int PLAYER_LAYER_MASK = 1 << 8;

        private Vector2 LocalForward => transform.right;
        private CreatureMover _mover;
        private EnemyAnimator _animator;
        private bool _attackCooldownFinished;
        private RaycastHit2D _playerRaycastHit;
        private ITimeService _timeService;

        private void Awake()
        {
            _timeService = ServicesContainer.Instance.Single<ITimeService>();
            
            _mover = new CreatureMover(GetComponent<Rigidbody2D>());
            _animator = new EnemyAnimator(GetComponent<Animator>());
            _attackCooldownFinished = true;
        }

        private void Update()
        {
            SearchPlayer();
            ProcessAttack();
            ProcessMovingToPlayer();
        }
        
        public void Damage(int amount)
        {
            _hp -= amount;
            Debug.Log($"Damage {gameObject.name} for {amount} hp");
            if (_hp <= 0)
                Death();
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
            if (!IsPlayerFound())
                return;

            _mover.RotateDirection(_playerRaycastHit.transform.position - transform.position);
            _mover.Move(LocalForward, _speed * Time.deltaTime);
        }

        private void Death()
        {
            Destroy(gameObject);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay((Vector2) transform.position + Vector2.left * _detectionRange, Vector2.right * _detectionRange * 2);
        }
    }
}