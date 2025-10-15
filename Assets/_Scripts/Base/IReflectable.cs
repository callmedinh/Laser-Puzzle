using System.Collections.Generic;
using _Scripts.Controller;

namespace _Scripts.Base
{
    public interface IReflectable
    {
        List<Direction> GetReflectedDirection(Direction incomingDirection);
    }
}