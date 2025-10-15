using System.Collections.Generic;
using _Scripts.Base;
using UnityEngine;

namespace _Scripts.Controller
{
    public static class DirectionHelper
    {
        public static Vector2 ConvertDirectionToVector(Direction direction)
        {
            return direction switch
            {
                Direction.Left => Vector2.left,
                Direction.Right => Vector2.right,
                Direction.Up => Vector2.up,
                Direction.Down => Vector2.down,
                _ => Vector2.zero
            };
        }

        public static Direction RotateDirectionClockwise(Direction direction)
        {
            return direction switch
            {
                Direction.Left => Direction.Down,
                Direction.Down => Direction.Right,
                Direction.Right => Direction.Up,
                Direction.Up => Direction.Left,
                _ => direction
            };
        }


        public static Direction GetOppositeDirection(Direction direction)
        {
            return direction switch
            {
                Direction.Left => Direction.Right,
                Direction.Right => Direction.Left,
                Direction.Up => Direction.Down,
                Direction.Down => Direction.Up,
                _ => direction
            };
        }
    }

    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }
}