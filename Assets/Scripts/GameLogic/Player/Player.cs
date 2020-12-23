using Infrastructure.Services;
using Infrastructure.Services.Abstract;
using UnityEngine;

namespace GameLogic.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _playerSpeed;
        
        private static readonly int PunchAnimationTrigger = Animator.StringToHash("Punch");
        
        private readonly Quaternion _defaultPosition = Quaternion.Euler(0, 0, 0);
        private readonly Quaternion _invertedPosition = Quaternion.Euler(0, 180, 0);
        
        private IInputService _inputService;
        private Rigidbody2D _rigidBody;
        private Vector2 _velocity;
        private Animator _animator;

        private void Awake()
        {
            _inputService = ServicesContainer.Instance.Single<IInputService>();
            _rigidBody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            ProcessMovement();
            ProcessAttack();
        }

        private void ProcessAttack()
        {
            if (!_inputService.IsAttackPressed())
                return;
            
            _animator.SetTrigger(PunchAnimationTrigger);
        }

        private void ProcessMovement()
        {
            _velocity = Vector2.zero;
            _velocity.x = _inputService.GetHorizontalInput() * _playerSpeed;

            if (_velocity.x < 0)
            {
                RotateToLeft();
            }
            else
            {
                RotateToRight();
            }
        }

        private void FixedUpdate()
        {
            var velocity = _rigidBody.velocity;
            velocity.x = _velocity.x * Time.fixedDeltaTime;
            _rigidBody.velocity = velocity;
        }
        
        // TODO: дублирование кода!
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
    }
}