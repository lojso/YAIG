using System;
using Infrastructure.Services.Abstract.Factories;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.Services.Factories
{
    public class CameraFactory : ICameraFactory
    {
        public event Action<Camera> OnCameraCreated;

        public Camera Camera { get; private set; }

        public Camera CreateCamera()
        {
            var cameraPrefab = Resources.Load<Camera>(AssetsPath.Camera);

            Camera = Object.Instantiate(cameraPrefab);
            OnCameraCreated?.Invoke(Camera);
            
            return Camera;
        }
    }
}