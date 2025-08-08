using System.Collections.Generic;
using _Scripts.Controller;
using UnityEngine;

namespace _Scripts.Base
{
    [CreateAssetMenu(menuName = "LaserPuzzle/Map")]
    public class MapSo : ScriptableObject
    {
        public List<BlockInfo> blocks;
        public List<BlockInfo> laserBlocks;
        public int width;
        public int height;
    }

    [System.Serializable]
    public class BlockInfo
    {
        public Vector2Int position;
        public BlockType type;
        public List<Direction> directions;
    }
    public enum BlockType
    {
        LaserSource,
        LaserReceiver,
        Mirror
    }
}