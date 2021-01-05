using Infrastructure.Services.Abstract.Factories;
using UnityEngine;

namespace Infrastructure.Services.Factories
{
    public class CameraFactory : ICameraFactory
    {
        public Camera CreateCamera()
        {
            var cameraPrefab = Resources.Load<Camera>(AssetsPath.Camera);
            return Object.Instantiate(cameraPrefab);
        }
    }
}