namespace Infrastructure.Services.Abstract
{
    public interface IShakeService
    {
        void ShakePosition(float force, float duration);
        void ShakeRotation(float force, float duration);
        void StopShake();
    }
}