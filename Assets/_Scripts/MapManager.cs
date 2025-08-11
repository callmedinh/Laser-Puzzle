using System.Collections.Generic;
using _Scripts.Base;
using _Scripts.Controller;
using _Scripts.Utilities;
using UnityEngine;

namespace _Scripts
{
    public class MapManager : Singleton<MapManager>
    {
        public MapSo map;
        public Pool pool;
        Point[,] _mapPoints;
        private int _width;
        private int _height;

        public void InitMap()
        {
            _width = map.mapSize.x;
            _height = map.mapSize.y;
            _mapPoints = new Point[_width, _height];
            for (int i = 0; i < map.blocks.Count; i++)
            {
                SpawnMirrorBlock(map.blocks[i]);
            }

            for (int i = 0; i < map.laserBlocks.Count; i++)
            {
                SpawnLaserBlock(map.laserBlocks[i]);;
            }
        }

        private void SpawnLaserBlock(BlockInfo blockInfo)
        {
            var obj = pool.GetPool(blockInfo.type);
            Vector2Int position = blockInfo.position;
            _mapPoints[position.x, position.y] = new Point(position.x, position.y, DirectionsConvertBasedType(blockInfo.type));
            Rotatable rotatable = obj.GetComponent<Rotatable>();
            if (rotatable != null)
            {
                rotatable.InitPosition(position);
            }
            obj.transform.position = new Vector3(position.x, position.y, 0);
            
            Direction direction = blockInfo.directions[0];
            LaserController laserController = obj.GetComponent<LaserController>();
            if (laserController != null)
            {
                laserController.StartTrace(position, direction);
            }

            _mapPoints[position.x, position.y].IsLaserOrigin = true;
        }
        private void SpawnMirrorBlock(BlockInfo blockInfo)
        {
            var obj = pool.GetPool(blockInfo.type);
            Vector2Int position = blockInfo.position;
            _mapPoints[position.x, position.y] = new Point(position.x, position.y,DirectionsConvertBasedType(blockInfo.type));
            Rotatable rotatable = obj.GetComponent<Rotatable>();
            if (rotatable != null)
            {
                rotatable.InitPosition(position);
            }
            obj.transform.position = new Vector3(position.x, position.y, 0);
            if (blockInfo.type == BlockType.LaserSource)
            {
                _mapPoints[position.x, position.y].IsReceivedLaser = true;
            }
        }

        public Point GetPoint(int x, int y)
        {
            if (x < 0 || y < 0 || x >= _width || y >= _height) return null;
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
                case BlockType.LaserReceiver: 
                    directions.Add(Direction.Left);
                    break;
                default:
                    break;
            }

            return directions;
        }
    }
}