using UnityEngine;

namespace GameLogic.Enemies
{
    public class EnemyAnimator
    {
        private readonly Animator _animator;
        private static readonly int _walking = Animator.StringToHash("IsWalking");
        private static readonly int _pucnh = Animator.StringToHash("Attack");
        private static readonly int _recieveDamage = Animator.StringToHash("ReceiveDamage");

        public EnemyAnimator(Animator animator)
        {
            _animator = animator;
        }
        
        public void Attack()=>
            _animator.SetTrigger(_pucnh);
        
        public void GetHit()=>
            _animator.SetTrigger(_recieveDamage);

        public void SetMovementVector(Vector2 velocity)
        {
            var isMoving = Mathf.Abs(velocity.x) >= float.Epsilon;
            _animator.SetBool(_walking, isMoving);
        }
    }
}