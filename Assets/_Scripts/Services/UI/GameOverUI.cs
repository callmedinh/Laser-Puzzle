using _Scripts.Base;
using _Scripts.UI;

namespace _Scripts.Services.UI
{
    public class GameOverUI : IUIService
    {
        public void ShowView()
        {
            UIManager.Instance.ChangeView(UIType.GameOver);
        }

        public UIBaseView GetView()
        {
            return UIManager.Instance.GetView(UIType.GameOver);
        }

        public void HideView()
        {
            UIManager.Instance.HideView();
        }
    }
}