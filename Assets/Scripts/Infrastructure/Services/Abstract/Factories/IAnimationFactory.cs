using UnityEngine;

namespace Infrastructure.Services.Abstract.Factories
{
    public interface IAnimationFactory
    {
        Animator CreateAnimationClipPrefab();
    }
}