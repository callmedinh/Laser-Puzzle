using _Scripts.Core.States;
using _Scripts.Services;
using _Scripts.Services.UI;
using _Scripts.Utilities;

namespace _Scripts.Core
{
    public class GameManager : Singleton<GameManager>
    {
        private StateMachine<GameState> _stateMachine;
        public override void Awake()
        {
            base.Awake();
            _stateMachine = new StateMachine<GameState>();
            _stateMachine.AddState(GameState.Gameplay, new GameplayState(new MapLoader(), new GameplayUI()));
            _stateMachine.AddState(GameState.Home, new HomeState(new HomeUI()));
            _stateMachine.AddState(GameState.GameOver, new GameOverState(new GameOverUI()));
            _stateMachine.AddState(GameState.Win, new WinState(new WinUI()));
        }

        private void Start()
        {
            _stateMachine.ChangeState(GameState.Home);
        }

        public void ChangeState(GameState state)
        {
            _stateMachine.ChangeState(state);
        }
    }

    public enum GameState
    {
        Gameplay,
        GameOver,
        Home,
        Win,
    }
}