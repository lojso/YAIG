using UnityEngine;

namespace Infrastructure.Services.Abstract.Factories
{
    public interface IAnimationFactory : IService
    {
        Animator CreateAnimationClipPrefab();
        Animator CreateCutscenePrefab();
    }
}