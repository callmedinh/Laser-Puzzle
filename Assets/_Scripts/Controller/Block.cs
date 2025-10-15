using System;
using System.Collections.Generic;
using _Scripts.Base;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Scripts.Controller
{
    public class Block : MonoBehaviour, IPointerClickHandler
    {
        private Rotatable _rotatable;
        public BlockType blockType;
        [SerializeField] private Laser _laser;
        public Direction direction;

        private void Start()
        {
            _rotatable = new Rotatable();
            _laser.InitalizeLaser(this.transform.position);
            if (blockType == BlockType.LaserSource)
            {
                _laser.Activate();
            }
        }

        private void Update()
        {
            
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            _rotatable.Rotate(90, transform);
            RotateDirection();
        }
        public void RotateDirection()
        {
            switch (direction)
            {
                case Direction.Left:
                    direction = Direction.Down;
                    break;
                case Direction.Down:
                    direction = Direction.Right;
                    break;
                case Direction.Right:
                    direction = Direction.Up;
                    break;
                case Direction.Up:
                    direction = Direction.Left;
                    break;
            }
        }
    }

}