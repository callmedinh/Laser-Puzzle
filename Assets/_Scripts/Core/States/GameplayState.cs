
using _Scripts.Controller;
using _Scripts.Services;
using _Scripts.UI.States;
using UnityEngine;
using IState = _Scripts.Base.IState;

namespace _Scripts.Core.States
{
    public class GameplayState: IState
    {
        private int _currentLevel;
        private readonly IMapService _mapService;
        private readonly IUIService _uiService;
        private Timer _timer;
        private GameplayViewState _gameplayViewState;

        public GameplayState(IMapService mapService = null, IUIService uiService = null, Timer timer = null)
        {
            _mapService = mapService ?? new MapService();
            _uiService = uiService ?? new GameplayUI();
            _timer = timer ?? new Timer(60);
        }
        public void Exit()
        {
            _uiService.HideView();
            _mapService.UnloadMap();
        }

        public void Enter()
        {
            _currentLevel = LevelManager.Instance.CurrentLevel;
            _mapService.LoadMap(_currentLevel);
            _uiService.ShowView();
            _gameplayViewState = _uiService.GetView() as GameplayViewState;
            if (_gameplayViewState == null)
            {
                Debug.LogError("GameplayViewState is not initialized properly.");
                return;
            }
            _gameplayViewState.Init(_timer);
            _timer.StartTimer();
        }

        public void Update()
        {
            _timer.Update();
            if (_timer.IsFinished)
            {
                _timer.StopTimer();
                GameManager.Instance.ChangeState(GameState.GameOver);
            }
        }
    }
}