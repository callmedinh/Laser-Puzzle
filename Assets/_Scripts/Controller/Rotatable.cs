using System;
using _Scripts.Base;
using _Scripts.Events;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Scripts.Controller
{
    public class Rotatable : MonoBehaviour, IRotation, IPointerClickHandler
    {
        [SerializeField] private float angle = 90;
        private Vector2Int _currentPosition;

        public void InitPosition(Vector2Int position)
        {
            _currentPosition = position;
        }
        public void Rotate(float value)
        {
            this.transform.DORotate(transform.eulerAngles + new Vector3(0,0, angle), 0.5f, RotateMode.FastBeyond360).SetEase(Ease.Linear);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Rotate(angle);
            Point point = MapManager.Instance.GetPoint(_currentPosition.x, _currentPosition.y);
            point.ChangeDirectionsList();
            BlockEvent.OnBlockRotated?.Invoke();
        }
    }
}
