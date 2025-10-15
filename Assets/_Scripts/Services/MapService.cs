using _Scripts.Base;
using _Scripts.Core;
using _Scripts.Services;
using _Scripts.UI;

namespace _Scripts.Services
{
    public class MapService : IMapService
    {
        public void LoadMap(int level)
        {
            var mapPrefab = UnityEngine.Resources.Load<MapSo>($"Maps/level_{level}");
            MapManager.Instance.InitMap(mapPrefab);
        }

        public void UnloadMap()
        {
            MapManager.Instance.ClearMap();
        }
    }
}

