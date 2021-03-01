using UnityEngine;

namespace Infrastructure.Services.Abstract
{
    public interface IFrameShakeService : IShakeService, IService
    {
        void SetUiTransform(Transform transform);
    }
}