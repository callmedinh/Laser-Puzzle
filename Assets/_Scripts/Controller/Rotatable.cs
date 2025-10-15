using _Scripts.Base;
using _Scripts.Events;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Scripts.Controller
{
    public class Rotatable : IRotation
    {
        private Vector2Int _currentPosition;
        private bool _isRotating = false;
        public void Rotate(float angle, Transform transform)
        {
            if (_isRotating) return;
            _isRotating = true;
            transform
                .DORotate(transform.eulerAngles + new Vector3(0, 0, angle), 0.5f, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .OnComplete(() => _isRotating = false);
        }
    }
}
