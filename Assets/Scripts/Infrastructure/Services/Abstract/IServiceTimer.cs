namespace Infrastructure.Services.Abstract
{
    public interface IServiceTimer : ITimer
    {
        bool IsFinished { get; }
        void Tick(float deltaTime);
    }
}