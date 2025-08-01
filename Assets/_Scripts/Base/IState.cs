namespace _Scripts.Base
{
    public interface IState
    {
        void Exit();
        void Enter();
        void Update();
    }
}