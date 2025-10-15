using _Scripts.Base;
using _Scripts.Controller;
using TMPro;
using UnityEngine;

namespace _Scripts.UI.States
{
    public class GameplayViewState : UIBaseView
    {
        [SerializeField] TMP_Text timeText, scoreText, levelText;
        private Timer _timer;

        public void Init(Timer timer)
        {
            _timer = timer;
            _timer.OnTimeChanged += UpdateTimeText;
        }

        private void UpdateTimeText(float obj)
        {
            if (timeText != null)
            {
                timeText.text = $"Time: {obj}";
            }
        }
    }
}