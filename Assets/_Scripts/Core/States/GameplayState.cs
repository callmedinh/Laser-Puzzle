
using IState = _Scripts.Base.IState;

namespace _Scripts.Core.States
{
    public class GameplayState: IState
    {
        public void Exit()
        {
            
        }

        public void Enter()
        {
            MapManager.Instance.InitMap();
        }

        public void Update()
        {
            
        }
    }
}