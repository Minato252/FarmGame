using System;
using UnityEngine;
using QFramework;
using UnityEngine.Tilemaps;

namespace FarmGame
{
    public partial class Player : ViewController
    {
        public Grid Grid;
        public Tilemap Tilemap;

        void Start()
        {
            // Code Here
        }

        private void Update()
        {
            // Debug.Log("transform"+transform.position.x+","+transform.position.y);
            //拿到主角的cellPosition
            var cellPosition = Grid.WorldToCell(transform.position);
            var grid = FindObjectOfType<GridController>().ShowGrid;
            //获得当前的坐标
            var tileWorldPos = Grid.CellToWorld(cellPosition);
            tileWorldPos.x += Grid.cellSize.x * 0.5f;
            tileWorldPos.y += Grid.cellSize.y * 0.5f;

            if (cellPosition.x < grid.Width && cellPosition.x >= 0 && cellPosition.y < grid.Height &&
                cellPosition.y >= 0)
            {
                ChooseController.Instance.Position(tileWorldPos);
            }

            if (Input.GetMouseButtonDown(0))
            {

                Debug.Log("cellPosition:" + cellPosition.x + "," + cellPosition.y);
                //将当前position设置为空

                if (cellPosition.x < grid.Width && cellPosition.x >= 0 && cellPosition.y < grid.Height &&
                    cellPosition.y >= 0)
                {
                    //开垦
                    if (grid[cellPosition.x, cellPosition.y]==null)
                    {
                        Tilemap.SetTile(cellPosition, FindObjectOfType<GridController>().Pen);
                        grid[cellPosition.x, cellPosition.y] = new SoilData();
                    }
                    //种地
                    else if(!grid[cellPosition.x, cellPosition.y].HasPlant)
                    {

                        //放种子
                        ResController.Instance.SeedPrefabs.Instantiate().Position(tileWorldPos);
                        
                        //设置状态
                        grid[cellPosition.x, cellPosition.y].HasPlant = true;
                    }
                }
            }
        }
    }
}