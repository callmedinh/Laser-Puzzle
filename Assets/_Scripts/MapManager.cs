using System;
using _Scripts.Base;
using _Scripts.Utilities;

namespace _Scripts
{
    public class MapManager : Singleton<MapManager>
    {
        public MapSo map;
        public Pool pool;

        public void InitMap()
        {
            for (int i = 0; i < map.blocks.Count; i++)
            {
                var obj = pool.GetPool(map.blocks[i].type);
                obj.transform.position = map.blocks[i].position;
            }
        }
    }
}