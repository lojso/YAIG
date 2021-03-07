using System.Collections;
using Infrastructure.Services.Abstract;
using Infrastructure.Services.Abstract.Factories;
using Infrastructure.StaticData;
using UnityEngine;

namespace Infrastructure.Services.Animation
{
    public class RoutineAnimationPopupService : IAnimationPopupClipsService
    {
        private readonly IAnimationFactory _animationFactory;
        private readonly IRuntimeService _runtimeService;
        private PopupAnimationsList _animations;
        
        public RoutineAnimationPopupService(IAnimationFactory animationFactory, IRuntimeService runtimeService)
        {
            _animationFactory = animationFactory;
            _runtimeService = runtimeService;
            _animations = Resources.Load<PopupAnimationsList>(AssetsPath.PopupAnimations);
        }
        
        public void PlayTestAnimation()
        {
            _runtimeService.StartCoroutine(PlayAnimationRoutine(_animations.TestAnimation));
        }

        public void PlayAnotherAnimation()
        {
            _runtimeService.StartCoroutine(PlayAnimationRoutine(_animations.AnotherTestAnimation));
        }

        public IEnumerator PlayAnimationRoutine(PopupAnimationData animation)
        {
            foreach (var frameData in animation.animationFrames)
            {
                Debug.Log("Delay: " + frameData.showDelaySec);
                yield return new WaitForSeconds(frameData.showDelaySec);
                var frame = _animationFactory.CreatePopupFrame();
                frame.SetImage(frameData.frameSprite);
                frame.FadeOut(frameData.frameLengthSec, frameData.fadeOutTimeSec);
            }
        }
    }
}