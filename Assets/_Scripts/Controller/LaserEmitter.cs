using System;
using System.Collections.Generic;
using _Scripts.Base;
using UnityEngine;

namespace _Scripts.Controller
{
    public class LaserEmitter : MonoBehaviour, ISwitchable
    {
        public List<Direction> directions;
        private Vector2 _startPoint;
        private Vector2 _currentEnd;
        private LineRenderer _lineRenderer;
        
        private void Start()
        {
            _startPoint = new Vector2(2, 0);
            _lineRenderer = GetComponent<LineRenderer>();
        }

        private void Update()
        {
            var nextPos = DirectionHelper.ConvertDirectionToVector(directions[0]) + _startPoint;
            _lineRenderer.positionCount = 2;
            _lineRenderer.SetPosition(0, _startPoint);
            _lineRenderer.SetPosition(1, _currentEnd);
            _currentEnd = Vector2.Lerp(_currentEnd, nextPos, Time.deltaTime * 5f);
        }

        public void Activate()
        {
            
        }

        public void Deactivate()
        {

        }
    }
}