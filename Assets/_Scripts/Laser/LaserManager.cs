using System.Collections.Generic;
using System.Numerics;

namespace _Scripts.Laser
{
    public class LaserManager
    {
        Queue<Vector2> _lasers = new Queue<Vector2>();
        public void AddLaser(Vector2 laserPosition)
        {
            _lasers.Enqueue(laserPosition);
        }
    }
}