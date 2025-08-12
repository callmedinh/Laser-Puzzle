
using _Scripts.Services;
using IState = _Scripts.Base.IState;

namespace _Scripts.Core.States
{
    public class GameplayState: IState
    {
        private int _currentLevel;
        private readonly IMapLoader _mapLoader;
        private readonly IUIService _uiService;

        public GameplayState(IMapLoader mapLoader = null, IUIService uiService = null)
        {
            _mapLoader = mapLoader ?? new MapLoader();
            _uiService = uiService ?? new GameplayUI();
        }
        public void Exit()
        {
            
        }

        public void Enter()
        {
            _currentLevel = LevelManager.Instance.CurrentLevel;
            _mapLoader.LoadMap(_currentLevel);
            _uiService.ShowView();
        }

        public void Update()
        {
            
        }
    }
}