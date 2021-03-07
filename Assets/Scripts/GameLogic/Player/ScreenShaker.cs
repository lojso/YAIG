using GameLogic.Enemies;
using Infrastructure.Services.Abstract;
using UnityEngine;

namespace GameLogic.Player
{
    public class ScreenShaker
    {
        private readonly IFrameShakeService _frameShakeService;
        private readonly ICameraShakeService _cameraShakeService;

        public ScreenShaker(IFrameShakeService frameShakeService, ICameraShakeService cameraShakeService)
        {
            _frameShakeService = frameShakeService;
            _cameraShakeService = cameraShakeService;
        }

        public void Shake(ShakeType type = ShakeType.Random)
        {
            switch (type)
            {
                case ShakeType.Unknown:
                    Debug.LogError("Unknow type of shaking: " + type);
                    ShakeFrame();
                    break;
                case ShakeType.Frame:
                    ShakeFrame();
                    break;
                case ShakeType.Camera:
                    ShakeCamera();
                    break;
                case ShakeType.Random:
                    ShakeRandom();
                    break;
            }
        }

        private void ShakeRandom()
        {
            if (Random.value > 0.5f)
            {
                ShakeFrame();
            }
            else
            {
                ShakeCamera();
            }
        }

        private void ShakeCamera()
        {
            _cameraShakeService.ShakePosition(0.3f, 0.5f);
            //_cameraShakeService.ShakeRotation(10, 0.5f);
        }

        private void ShakeFrame()
        {
            _frameShakeService.ShakePosition(10, 0.5f);
            //_frameShakeService.ShakeRotation(10, 0.5f);
        }
    }
}