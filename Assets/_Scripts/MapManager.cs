using System.Collections.Generic;
using _Scripts.Base;
using _Scripts.Controller;
using _Scripts.Utilities;
using UnityEngine;

namespace _Scripts
{
    public class MapManager : Singleton<MapManager>
    {
        public Pool pool;
        Point[,] _mapPoints;
        private Vector2Int _mapSize;

        public void InitMap(MapSo map)
        {
            this._mapSize = map.mapSize;
            _mapPoints = new Point[_mapSize.x, _mapSize.y];
            for (int i = 0; i < map.blocks.Count; i++)
            {
                SpawnMirrorGateBlock(map.blocks[i]);
            }

            for (int i = 0; i < map.laserBlocks.Count; i++)
            {
                SpawnLaserBlock(map.laserBlocks[i]);
            }
        }

        public void ClearMap()
        {
            if (pool != null)
            {
                pool.DeactivateAll(); // assuming you have this method in your Pool
            }
            if (_mapPoints != null)
            {
                for (int x = 0; x < _mapSize.x; x++)
                {
                    for (int y = 0; y < _mapSize.y; y++)
                    {
                        _mapPoints[x, y] = null;
                    }
                }
            }
            
            _mapSize = Vector2Int.zero;
        }
        private void SpawnLaserBlock(BlockInfo blockInfo)
        {
            var obj = pool.GetPool(blockInfo.type);
            Vector2Int position = blockInfo.position;
            List<Direction> directions = DirectionsConvertBasedType(blockInfo.type);
            _mapPoints[position.x, position.y] = new Point(position.x, position.y);
            obj.transform.position = new Vector3(position.x, position.y, 0);
            _mapPoints[position.x, position.y].IsLaserOrigin = true;
        }
        private void SpawnMirrorGateBlock(BlockInfo blockInfo)
        {
            var obj = pool.GetPool(blockInfo.type);
            Vector2Int position = blockInfo.position;
            List<Direction> directions = DirectionsConvertBasedType(blockInfo.type);
            _mapPoints[position.x, position.y] = new Point(position.x, position.y);
            obj.transform.position = new Vector3(position.x, position.y, 0);
            if (blockInfo.type == BlockType.Gate)
            {
                _mapPoints[position.x, position.y].IsGate = true;
            }
            else
            {
                _mapPoints[position.x, position.y].IsMirror = true;
            }
        }

        public Point GetPoint(int x, int y)
        {
            if (x < 0 || y < 0 || x >= _mapSize.x || y >= _mapSize.y) return null;
            return _mapPoints[x, y];
        }

        public List<Direction> DirectionsConvertBasedType(BlockType type)
        {
            var directions = new List<Direction>();
            switch (type)
            {
                case BlockType.Mirror01:
                    directions.Add(Direction.Left);
                    directions.Add(Direction.Right);
                    break;
                case BlockType.Mirror02:
                    directions.Add(Direction.Up);
                    directions.Add(Direction.Left);   
                    break;
                case BlockType.Mirror03:
                    directions.Add(Direction.Up);
                    directions.Add(Direction.Left);
                    directions.Add(Direction.Down);   
                    break;
                case BlockType.LaserSource:
                    directions.Add(Direction.Left);
                    break;
                case BlockType.Gate: 
                    directions.Add(Direction.Left);
                    break;
            }

            return directions;
        }
    }
}