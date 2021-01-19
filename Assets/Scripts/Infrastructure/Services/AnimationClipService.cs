using Infrastructure.Services.Abstract;
using Infrastructure.Services.Abstract.Factories;
using UnityEngine;

namespace Infrastructure.Services
{
    public class AnimationClipService : IAnimationClipsService
    {
        private readonly IAnimationFactory _animationFactory;
        private readonly int TestAnimationTrigger = Animator.StringToHash("TestAnimation");
        private readonly int AnotherAnimationTrigger = Animator.StringToHash("AnotherAnimation");
        private readonly string IdleAnimationStateName = "IdleAnimation";
        private readonly Animator _animator;

        private bool IsIdle => _animator.GetCurrentAnimatorStateInfo(0).IsName(IdleAnimationStateName);

        public AnimationClipService(IAnimationFactory _animationFactory)
        {
            this._animationFactory = _animationFactory;
        }

        public void PlayTestAnimation()
        {
            if(IsIdle)
                _animator.Play(TestAnimationTrigger);
        }

        public void PlayAnotherAnimation()
        {
            if(IsIdle)
                _animator.Play(AnotherAnimationTrigger);
        }
    }
}