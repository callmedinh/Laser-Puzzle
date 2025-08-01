using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Base
{
    [CreateAssetMenu(menuName = "LaserPuzzle/Map")]
    public class MapSo : ScriptableObject
    {
        public List<BlockInfo> blocks;
    }

    [System.Serializable]
    public class BlockInfo
    {
        public Vector2 position;
        public BlockType type;
    }
    public enum BlockType
    {
        LaserSource,
        LaserReceiver,
        Mirror
    }
}