using System;
using _Scripts.Base;
using _Scripts.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.States
{
    public class WinViewState : UIBaseView
    {
        [SerializeField] private Button nextLevelButton, homeButton;
        [SerializeField] private TMP_Text timeText, scoreText, levelText;

        private void OnEnable()
        {
            if (timeText != null && scoreText != null && levelText != null)
            {
                /*
                timeText.text = $"Time: {GameManager.Instance.GameplayState.Time}";
                scoreText.text = $"Score: {GameManager.Instance.GameplayState.Score}";
                levelText.text = $"Level: {GameManager.Instance.GameplayState.Level}";
                */
            }
            nextLevelButton.onClick.AddListener(NextLevelButtonClicked);
            homeButton.onClick.AddListener(HomeButtonClicked);
        }
        private void OnDisable()
        {
            nextLevelButton.onClick.RemoveListener(NextLevelButtonClicked);
            homeButton.onClick.RemoveListener(HomeButtonClicked);
        }

        private void NextLevelButtonClicked()
        {
            GameManager.Instance.ChangeState(GameState.Gameplay);
        }
        private void HomeButtonClicked()
        {
            GameManager.Instance.ChangeState(GameState.Home);
        }
    }
}