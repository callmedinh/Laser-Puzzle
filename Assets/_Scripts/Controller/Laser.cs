using System;
using _Scripts.Base;
using UnityEngine;

namespace _Scripts.Controller
{
    public class Laser : MonoBehaviour, ISwitchable
    {
        private LineRenderer _lineRender;
        private Vector2 _currentEnd;
        private Vector2 _startPoint;
        private Vector2 _targetEnd;
        private Vector2 _minTargetEnd;
        public Direction direction;

        private void Awake()
        {
            _lineRender = GetComponent<LineRenderer>();
            _lineRender.positionCount = 0;
        }

        private void Update()
        {
            var result = new Vector3();
            switch (direction)
            {
                case Direction.Down:
                    result = -transform.up;
                    break;
                case Direction.Up: 
                    result = transform.up;
                    break;
                case Direction.Left: 
                    result = -transform.right;
                    break;
                case Direction.Right: 
                    result = transform.right;
                    break;
            }
            EmitLaserBeam(result);
        }

        public void InitalizeLaser(Vector2 startPoint)
        {
            _startPoint = startPoint;
            _currentEnd = startPoint;
        }

        public void EmitLaserBeam(Vector2 direction)
        { 
            _targetEnd = direction + new Vector2(_startPoint.x, _startPoint.y);
            _currentEnd = Vector2.Lerp(_currentEnd, _targetEnd, Time.deltaTime * 5f);
            if (_lineRender.positionCount == 2)
            {
                _lineRender.SetPosition(0, _startPoint);
                _lineRender.SetPosition(1, _currentEnd);
            }
        }

        public void Activate()
        {
            _lineRender.positionCount = 2;
        }

        public void Deactivate()
        {
            _lineRender.positionCount = 0;
        }
    }
}
