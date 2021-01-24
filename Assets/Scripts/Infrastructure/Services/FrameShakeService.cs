using Infrastructure.Services.Abstract;
using Infrastructure.Services.Abstract.Factories;
using Infrastructure.Services.Factories;
using UnityEngine;

namespace Infrastructure.Services
{
    public class FrameShakeService : ShakeService, IFrameShakeService
    {
        protected override Transform Transform { get; set; }
        
        public FrameShakeService(IUiFactory uiFactory, IRuntimeService runtimeService) : base(runtimeService)
        {
            if (uiFactory.Ui != null)
            {
                Transform = uiFactory.Ui.Frame.transform;
            }

            uiFactory.OnUiCreated += ui => Transform = ui.Frame.transform;
        }

        protected override void OnShakePosition() => 
            Transform.gameObject.SetActive(true);

        protected override void OnShakeRotation() => 
            Transform.gameObject.SetActive(true);

        protected override void OnStopShake() => 
            Transform.gameObject.SetActive(false);
    }
}