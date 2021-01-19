using System;
using Infrastructure.Services;
using Infrastructure.Services.Abstract;
using UnityEngine;

namespace GameLogic.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _playerSpeed = 200f;
        [SerializeField] private float _attackCooldownSec = 0.1f;
        [SerializeField] private int _health = 20;

        public event Action<Player> OnDeath;
        
        private IInputService _inputService;
        private ITimeService _timeService;
        private Vector2 _velocity;
        private PlayerAnimator _animator;
        private CreatureMover _mover;
        private bool _canAttack;

        private void Awake()
        {
            _inputService = ServicesContainer.Instance.Single<IInputService>();
            _timeService = ServicesContainer.Instance.Single<ITimeService>();
            _animator = new PlayerAnimator(GetComponent<Animator>());

            _mover = new CreatureMover(GetComponent<Rigidbody2D>());

            _canAttack = true;
        }

        private void Update()
        {
            ProcessMovementInput();
            ProcessAttack();
        }

        private void ProcessAttack()
        {
            if (!_inputService.IsAttackPressed() || !_canAttack)
                return;
            
            _animator.Attack();
            _canAttack = false;

            _timeService.StartTimer(_attackCooldownSec, null, () => _canAttack = true);
        }

        private void ProcessMovementInput()
        {
            _velocity = Vector2.zero;
            _velocity.x = _inputService.GetHorizontalInput();
        }

        private void FixedUpdate()
        {
            _mover.Stop();
            if(_velocity == Vector2.zero)
                return;

            _mover.Move(_velocity.normalized, _playerSpeed * Time.fixedDeltaTime);
        }

        public void Damage(int damage)
        {
            if(_health <= 0)
                return;
            
            _health -= damage;
            Debug.Log($"Player damaged by {damage}. Current health: {_health}");
            if(_health <= 0)
            {
                OnDeath?.Invoke(this);
            }
        }
    }
}