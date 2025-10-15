using System.Collections.Generic;
using _Scripts.Base;
using _Scripts.Utilities;
using UnityEngine;

namespace _Scripts.UI
{
    public class UIManager : Singleton<UIManager>
    {
        Dictionary<UIType, UIBaseView> _uiMap = new();
        [SerializeField] UIBaseView homeView, gameplayView, gameOverView, winView;
        private UIBaseView _currentView;
        private Queue<UIBaseView> _viewQueue = new();
        public override void Awake()
        {
            base.Awake();
            _uiMap[UIType.Gameplay] = gameplayView;
            _uiMap[UIType.GameOver] = gameOverView;
            _uiMap[UIType.Home] = homeView;
            _uiMap[UIType.WinPopup] = winView;
        }
        public void ChangeView(UIType type)
        {
            _currentView = _uiMap[type];
            _currentView.Show();
        }

        public UIBaseView GetView(UIType type)
        {
            if (_uiMap.TryGetValue(type, out var view))
            {
                return view;
            }
            else
            {
                Debug.LogError($"UIType {type} not found in UIManager.");
                return null;
            }
        }
        public void HideView()
        {
            _currentView.Hide();
        }
    }
    public enum UIType
    {
        Gameplay,
        GameOver,
        Home,
        WinPopup,
        SettingsPopup,
        PausePopup,
    } 
}