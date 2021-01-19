using Infrastructure.Services.Abstract.Factories;
using UnityEngine;

namespace Infrastructure.Services.Factories
{
    public class AnimationFactory : IAnimationFactory
    {
        public Animator CreateAnimationClipPrefab()
        {
            var cameraPrefab = Resources.Load<Animator>(AssetsPath.AnimationClip);
            return Object.Instantiate(cameraPrefab);       
        }
    }
}