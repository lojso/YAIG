namespace Infrastructure.States
{
    public interface IExitableState
    {
        void Exit();
    }

    public interface IState : IExitableState
    {
        void Enter();
    }

    public interface IContextState<TContext> : IExitableState
    {
        void Enter(TContext context);
    }
}