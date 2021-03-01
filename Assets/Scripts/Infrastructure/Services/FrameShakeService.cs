using Infrastructure.Services.Abstract;
using Infrastructure.Services.Abstract.Factories;
using Infrastructure.Services.Factories;
using UnityEngine;

namespace Infrastructure.Services
{
    public class FrameShakeService : ShakeService, IFrameShakeService
    {
        protected override Transform Transform { get; set; }
        
        public FrameShakeService(IRuntimeService runtimeService) : base(runtimeService) { }

        public void SetUiTransform(Transform transform) => 
            Transform = transform;

        protected override void OnShakePosition() => 
            Transform.gameObject.SetActive(true);

        protected override void OnShakeRotation() => 
            Transform.gameObject.SetActive(true);

        protected override void OnStopShake() => 
            Transform.gameObject.SetActive(false);
    }
}