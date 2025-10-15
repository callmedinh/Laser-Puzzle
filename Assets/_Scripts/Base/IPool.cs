using UnityEngine;

namespace _Scripts.Base
{
    public interface IPool
    {
        GameObject PooledObject { get; }
        public void ReturnToPool(GameObject obj);
        public void GetPooledObject();
        public void ClearPool();
    }
}