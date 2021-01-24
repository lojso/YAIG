using Infrastructure.Services.Abstract;
using Infrastructure.Services.Abstract.Factories;
using UnityEngine;

namespace Infrastructure.Services
{
    public class CameraShakeService : ShakeService, ICameraShakeService
    {
        protected override Transform Transform { get; set; }
        
        public CameraShakeService(ICameraFactory cameraFactory, IRuntimeService runtimeService) : base(runtimeService)
        {
            if (cameraFactory.Camera != null)
            {
                Transform = cameraFactory.Camera.transform;
            }
            cameraFactory.OnCameraCreated += camera => Transform = camera.transform;
        }
    }
}
