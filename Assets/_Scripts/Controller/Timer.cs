using System;
using UnityEngine;

namespace _Scripts.Controller
{
    public class Timer
    {
        private float _startTime;
        private float _duration;
        private bool _isRunning;
        public event Action<float> OnTimeChanged;

        public Timer(float duration)
        {
            _duration = duration;
        }
        public void Update()
        {
            if (!_isRunning) return;
            
            OnTimeChanged?.Invoke(Mathf.FloorToInt(RemainingTime));
        }

        public void StartTimer()
        {
            _startTime = Time.time;
            _isRunning = true;
        }

        public void StopTimer()
        {
            _isRunning = false;
        }

        // Thời gian đã trôi qua
        public float ElapsedTime
        {
            get
            {
                if (!_isRunning) return 0f;
                return Time.time - _startTime;
            }
        }

        // Thời gian còn lại
        public float RemainingTime
        {
            get
            {
                if (!_isRunning) return _duration;
                return Mathf.Max(0, _duration - ElapsedTime);
            }
        }

        // Kiểm tra đã hết giờ chưa
        public bool IsFinished => ElapsedTime >= _duration;
    }
}