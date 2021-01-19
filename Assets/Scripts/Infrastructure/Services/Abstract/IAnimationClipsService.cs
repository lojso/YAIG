using UnityEngine;

namespace Infrastructure.Services.Abstract
{
    public interface IAnimationClipsService : IService
    {
        void PlayTestAnimation();
        void PlayAnotherAnimation();
    }
}