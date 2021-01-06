using UnityEngine;

namespace GameLogic.Player
{
    public class PlayerAnimator
    {
        private readonly Animator _animator;
        private static readonly int Move = Animator.StringToHash("Walking");
        private static readonly int Pucnh = Animator.StringToHash("Punch");
        private static readonly int Idle = Animator.StringToHash("Idle");

        public PlayerAnimator(Animator animator)
        {
            _animator = animator;
        }
        
        public void Attack()=>
            _animator.SetTrigger(Pucnh);
    }
}