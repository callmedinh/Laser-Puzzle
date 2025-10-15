using _Scripts.Base;
using _Scripts.Services;
using _Scripts.Services.UI;
using _Scripts.UI;

namespace _Scripts.Core.States
{
    public class HomeState: IState
    {
        private readonly IUIService _uiService;

        public HomeState(IUIService uiService = null)
        {
            _uiService = uiService ?? new HomeUI();
        }
        public void Exit()
        {
            _uiService.HideView();
        }

        public void Enter()
        {
            _uiService.ShowView();
        }

        public void Update()
        {
            
        }
    }
}