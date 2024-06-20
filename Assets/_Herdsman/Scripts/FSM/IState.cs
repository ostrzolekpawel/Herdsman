namespace Herdsman.FSM
{
    public interface IState<T>
    {
        void Enter();
        void Exit();
        T Execute();
        bool CanChange(T nextState);
    }
}