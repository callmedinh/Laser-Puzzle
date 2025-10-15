using _Scripts.Base;
using _Scripts.UI;

namespace _Scripts.Services
{
    public class GameplayUI : IUIService
    {
        public void ShowView()
        {
            UIManager.Instance.ChangeView(UIType.Gameplay);
        }

        public UIBaseView GetView()
        {
            return UIManager.Instance.GetView(UIType.Gameplay);
        }

        public void HideView()
        {
            UIManager.Instance.HideView();
        }
    }
}