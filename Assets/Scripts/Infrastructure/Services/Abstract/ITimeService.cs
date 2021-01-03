using System;

namespace Infrastructure.Services.Abstract
{
    public interface ITimeService : IService
    {
        ITimer StartTimer(float attackCooldownSec, Action<float> onProgress, Action onFinish);
    }
}