﻿using System.Data;
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

        private IInputService _inputService;
        private Vector2 _velocity;
        private Animator _animator;
        private CreatureMover _mover;

        private void Awake()
        {
            _inputService = ServicesContainer.Instance.Single<IInputService>();
            _animator = GetComponent<Animator>();

            _mover = new CreatureMover(GetComponent<Rigidbody2D>());
        }

        private void Update()
        {
            ProcessMovementInput();
            ProcessAttack();
        }

        private void ProcessAttack()
        {
            if (!_inputService.IsAttackPressed())
                return;

            _animator.SetTrigger(PunchAnimationTrigger);
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

            _mover.RotateDirection(_velocity);
            _mover.Move(_velocity.normalized, _playerSpeed * Time.fixedDeltaTime);
        }
    }
}