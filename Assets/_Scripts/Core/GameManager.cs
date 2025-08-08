using System;
using _Scripts.Core.States;
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
            _stateMachine.AddState(GameState.Gameplay, new GameplayState());
        }

        private void Start()
        {
            _stateMachine.ChangeState(GameState.Gameplay);
        }
    }

    public enum GameState
    {
        Gameplay,
        GameOver,
        MainMenu,
    }
}