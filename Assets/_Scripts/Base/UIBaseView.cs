using UnityEngine;

namespace _Scripts.Base
{
    public abstract class UIBaseView : MonoBehaviour
    {
        public void Show()
        {
            this.gameObject.SetActive(true);
            OnShow();
        }

        public void Hide()
        {
            OnHide();
            this.gameObject.SetActive(false);
        }

        public virtual void OnShow()
        {
            
        }

        public virtual void OnHide()
        {
            
        }
    }
}