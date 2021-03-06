using GameLogic.Animation;
using Infrastructure.Services.Abstract.Factories;
using UnityEngine;

namespace Infrastructure.Services.Factories
{
    public class AnimationFactory : IAnimationFactory
    {
        private readonly IUiFactory _uiFactory;
        private Canvas _canvas;

        public AnimationFactory(IUiFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public Animator CreateAnimationClipPrefab()
        {
            var animationClip = Resources.Load<Animator>(AssetsPath.AnimationClip);

            return Object.Instantiate(animationClip, _uiFactory.Ui.Canvas.transform);
        }

        public Animator CreateCutscenePrefab()
        {
            var animationClip = Resources.Load<Animator>(AssetsPath.AnimationClip);

            return Object.Instantiate(animationClip, _uiFactory.Ui.Canvas.transform);
        }

        public PopupFrame CreatePopupFrame()
        {
            var popupFrame = Resources.Load<PopupFrame>(AssetsPath.PopupFrame);
            return Object.Instantiate(popupFrame, _uiFactory.Ui.Canvas.transform);
        }
    }
}