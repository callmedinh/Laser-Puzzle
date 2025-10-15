using _Scripts.Base;
using _Scripts.UI;

namespace _Scripts.Services.UI
{
    public class HomeUI : IUIService
    {
        public void ShowView()
        {
            UIManager.Instance.ChangeView(UIType.Home);
        }

        public UIBaseView GetView()
        {
            return UIManager.Instance.GetView(UIType.Home);
        }
        public void HideView()
        {
            UIManager.Instance.HideView();
        }
    }
}