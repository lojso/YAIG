using System;
using Infrastructure.Services;
using Infrastructure.Services.Abstract;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _playerSpeed;
        
        private IInputService _inputService;
        private Rigidbody2D _rigidBody;
        private Vector2 _velocity;

        private void Awake()
        {
            _inputService = ServicesContainer.Instance.Single<IInputService>();
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _velocity = Vector2.zero;
            
            float x = _inputService.GetHorizontalInput();

            _velocity.x = x * _playerSpeed;
        }

        private void FixedUpdate()
        {
            
            var velocity = _rigidBody.velocity;
            velocity.x = _velocity.x * Time.fixedDeltaTime;
            _rigidBody.velocity = velocity;
        }
    }
}