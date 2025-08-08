using System.Collections.Generic;
using _Scripts.Base;
using UnityEngine;

namespace _Scripts.Utilities
{
    public class Pool : MonoBehaviour
    {
        private Dictionary<BlockType, Stack<GameObject>> _pools = new Dictionary<BlockType, Stack<GameObject>>();
        public List<PoolItem> poolItems;

        private void Awake()
        {
            InitPools();
        }

        void InitPools()
        {
            foreach (var item in poolItems)
            {
                if (!_pools.ContainsKey(item.type))
                {
                    _pools[item.type] = new Stack<GameObject>();
                }
                for (int i = 0; i < item.size; i++)
                {
                    var obj = Instantiate(item.prefab, transform);
                    obj.SetActive(false);
                    _pools[item.type].Push(obj);
                }
            }
        }

        public GameObject GetPool(BlockType type)
        {
            GameObject block = null;
            if (_pools.TryGetValue(type, out var stack))
            {
                stack.TryPop(out var obj);
                block = obj;
                block.SetActive(true);
            }
            return block;
        }
        public void ReturnPool(BlockType type, GameObject block)
        {
            block.SetActive(false);
            if (_pools.TryGetValue(type, out var stack))
            {
                stack.Push(block);
            }
        }
    }

    [System.Serializable]
    public class PoolItem
    {
        public int size;
        public BlockType type;
        public GameObject prefab;
    }
}