using _Scripts.Base;
using _Scripts.UI;

namespace _Scripts.Services.UI
{
    public class WinUI : IUIService
    {
        public void ShowView()
        {
            UIManager.Instance.ChangeView(UIType.WinPopup);
        }

        public UIBaseView GetView()
        {
            return UIManager.Instance.GetView(UIType.WinPopup);
        }
        public void HideView()
        {
            UIManager.Instance.HideView();
        }
    }
}