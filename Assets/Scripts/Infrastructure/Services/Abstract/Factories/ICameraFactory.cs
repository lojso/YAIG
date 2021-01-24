using System;
using UnityEngine;

namespace Infrastructure.Services.Abstract.Factories
{
    public interface ICameraFactory : IService
    {
        event Action<Camera> OnCameraCreated;
        Camera Camera { get; }
        Camera CreateCamera();
    }
}