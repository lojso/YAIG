using UnityEngine;

namespace Infrastructure.Services.Abstract
{
    public interface IAnimationPopupClipsService : IService
    {
        void PlayTestAnimation();
        void PlayAnotherAnimation();
    }
}