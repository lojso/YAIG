using System;
using System.Collections.Generic;
using Infrastructure.Services.Abstract;
using UnityEngine;

namespace Infrastructure.Services
{
    public class TimeService : MonoBehaviour, ITimeService
    {
        private List<IServiceTimer> _timers;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _timers = new List<IServiceTimer>();
        }
        
        public ITimer StartTimer(float attackCooldownSec, Action<float> onProgress, Action onFinish)
        {
            var timer = new Timer(attackCooldownSec, onProgress, onFinish);
            _timers.Add(timer);
            return timer;
        }

        private void Update()
        {
            TickTimers(Time.deltaTime);
            RemoveFinishedTimers();
        }

        private void TickTimers(float deltaTime)
        {
            _timers.ForEach(timer => timer.Tick(deltaTime));
        }

        private void RemoveFinishedTimers()
        {
            _timers.RemoveAll(timer => timer.IsFinished);
        }
    }
}