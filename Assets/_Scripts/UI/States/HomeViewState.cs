using System;
using _Scripts.Base;
using _Scripts.Core;
using UnityEditor.Search;
using UnityEngine.UI;

namespace _Scripts.UI.States
{
    public class HomeViewState : UIBaseView
    {
        public Button playButton, settingButton, achievementButton;

        private void OnEnable()
        {
            playButton.onClick.AddListener(PlayButtonClicked);
        }
        private void OnDisable()
        {
            playButton.onClick.RemoveListener(PlayButtonClicked);
        }

        private void PlayButtonClicked()
        {
            GameManager.Instance.ChangeState(GameState.Gameplay);
        }
    }
}