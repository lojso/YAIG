using Infrastructure.Services.Abstract;
using Infrastructure.Services.Abstract.Factories;
using UnityEngine;

namespace Infrastructure.Services.Animation
{
    public class MechanimAnimationClipService : IAnimationPopupClipsService
    {
        private readonly int TestAnimationTrigger = Animator.StringToHash("TestAnimation");
        private readonly int AnotherAnimationTrigger = Animator.StringToHash("AnotherAnimation");
        private readonly string IdleAnimationStateName = "IdleAnimation";
        private readonly IAnimationFactory _animationFactory;
        
        public Animator Animator
        {
            get
            {
                if (_animator == null)
                {
                    _animator = _animationFactory.CreateAnimationClipPrefab();
                }
                return _animator;
            }
        }
        private Animator _animator;
        private bool IsIdle => Animator.GetCurrentAnimatorStateInfo(0).IsName(IdleAnimationStateName);


        public MechanimAnimationClipService(IAnimationFactory animationFactory)
        {
            _animationFactory = animationFactory;
        }

        public void PlayTestAnimation()
        {
            if(IsIdle)
                Animator.Play(TestAnimationTrigger);
        }

        public void PlayAnotherAnimation()
        {
            if(IsIdle)
                Animator.Play(AnotherAnimationTrigger);
        }
    }
}