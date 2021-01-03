using UnityEngine;

namespace GameLogic.Enemies
{
    public class EnemyAnimator
    {
        private readonly Animator _animator;
        private static readonly int MoveHash = Animator.StringToHash("Walking");
        private static readonly int Pucnh = Animator.StringToHash("Punch");
        private static readonly int Idle = Animator.StringToHash("Idle");

        public EnemyAnimator(Animator animator)
        {
            _animator = animator;
        }
        
        public void Attack()=>
            _animator.SetTrigger(Pucnh);
    }
}