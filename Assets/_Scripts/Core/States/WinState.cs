using _Scripts.Base;
using _Scripts.Services;
using _Scripts.Services.UI;

namespace _Scripts.Core.States
{
    public class WinState : IState
    {
        private readonly IUIService _uiService;
        public WinState(IUIService uiService = null)
        {
            _uiService = uiService ?? new WinUI();
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