using System;
using _Scripts.Base;
using _Scripts.Core;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.States
{
    public class GameOverViewState : UIBaseView
    {
        [SerializeField] private Button replayButton, homeButton;
        private void OnEnable()
        {
            replayButton.onClick.AddListener(ReplayButtonClicked);
            homeButton.onClick.AddListener(HomeButtonClicked);
        }

        private void OnDisable()
        {
            replayButton.onClick.RemoveListener(ReplayButtonClicked);
            homeButton.onClick.RemoveListener(HomeButtonClicked);
        }
        private void ReplayButtonClicked()
        {
            GameManager.Instance.ChangeState(GameState.Gameplay);
        }

        private void HomeButtonClicked()
        {
            GameManager.Instance.ChangeState(GameState.Home);
        }
    }
}