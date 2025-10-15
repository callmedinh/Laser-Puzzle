using _Scripts.Base;
using UnityEngine;

namespace _Scripts.Utilities
{
    public class LineRendererPool : IPool
    {
        public GameObject PooledObject { get; }
        public void ReturnToPool(GameObject obj)
        {
            throw new System.NotImplementedException();
        }

        public void GetPooledObject()
        {
            throw new System.NotImplementedException();
        }

        public void ClearPool()
        {
            throw new System.NotImplementedException();
        }
    }
}