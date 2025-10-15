
using System.Collections.Generic;
using _Scripts.Controller;

namespace _Scripts
{
    public class Point
    {
        private int X { get; set; }
        private int Y { get; set; }
        public bool IsGate { get; set; }
        public bool IsMirror { get; set; }
        public bool IsLaserOrigin { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}