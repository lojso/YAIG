namespace Infrastructure.Services.Abstract
{
    public interface IInputService : IService
    {
        float GetHorizontalInput();
        bool IsAttackPressed();
        bool IsBlockPressed();
    }
}