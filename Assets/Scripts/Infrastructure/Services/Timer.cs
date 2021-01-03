using System;
using Infrastructure.Services.Abstract;

namespace Infrastructure.Services
{
    public class Timer : IServiceTimer
    {
        public bool IsFinished => _currentTimerTime <= 0;
        
        private readonly float _timerTime;
        private readonly Action<float> _onProgress;
        private readonly Action _onFinish;
        
        private float _currentTimerTime;
        
        public Timer(float timerTime, Action<float> onProgress, Action onFinish)
        {
            _timerTime = timerTime;
            _onProgress = onProgress;
            _onFinish = onFinish;

            _currentTimerTime = _timerTime;
        }

        public void Tick(float deltaTime)
        {
            if(IsFinished)
                return;
            
            _currentTimerTime -= deltaTime;
            _onProgress?.Invoke(_timerTime / _currentTimerTime);
            
            if(IsFinished)
                _onFinish?.Invoke();
        }

        public void Stop()
        {
            _currentTimerTime = 0;
        }
    }
}