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
            if (_uiFactory.Canvas == null)
            {
                _uiFactory.CreateCanvas();
            }
            return Object.Instantiate(animationClip, _uiFactory.Canvas.transform);
        }
    }
}