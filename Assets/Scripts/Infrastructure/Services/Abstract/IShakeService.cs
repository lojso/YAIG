namespace Infrastructure.Services.Abstract
{
    public interface IShakeService : IService
    {
        void ShakePosition(float force, float duration);
        void ShakeRotation(float force, float duration);
        void StopShake();
    }
}