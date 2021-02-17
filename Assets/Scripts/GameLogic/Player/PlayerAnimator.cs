using UnityEngine;

namespace GameLogic.Player
{
    public class PlayerAnimator
    {
        private readonly Animator _animator;
        private static readonly int _walking = Animator.StringToHash("IsWalking");
        private static readonly int _pucnh = Animator.StringToHash("Punch");
        private static readonly int _recieveDamage = Animator.StringToHash("ReceiveDamage");
        private static readonly int _block = Animator.StringToHash("Block");

        public PlayerAnimator(Animator animator)
        {
            _animator = animator;
        }
        
        public void Attack()=>
            _animator.SetTrigger(_pucnh);
        
        public void Block()=>
            _animator.SetTrigger(_block);
        
        public void GetHit()=>
            _animator.SetTrigger(_recieveDamage);

        public void SetMovementVector(Vector2 velocity)
        {
            var isMoving = Mathf.Abs(velocity.x) >= float.Epsilon;
            _animator.SetBool(_walking, isMoving);
        }
    }
}