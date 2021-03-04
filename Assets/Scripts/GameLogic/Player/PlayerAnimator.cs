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

        private static readonly string _idleState = "PlayerIdle";
        private static readonly string _blockState = "PlayerBlock";
        private static readonly string _walkState = "PlayerWalk";
        private static readonly string _reciveHitState = "PlayerReciveHit";
        private static readonly string _punchState = "PlayerPunch";

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

        public bool IsIdle()
        {
            return _animator.GetCurrentAnimatorStateInfo(0).IsName(_idleState);
        }

        public bool IsWalking()
        {
            return _animator.GetCurrentAnimatorStateInfo(0).IsName(_walkState);
        }
    }
}