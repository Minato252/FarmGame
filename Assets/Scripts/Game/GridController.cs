using UnityEngine;
using QFramework;
using Unity.VisualScripting;
using UnityEngine.Tilemaps;

namespace FarmGame
{
	public partial class GridController : ViewController
	{
		private EasyGrid<SoilData> mShowGrid = new EasyGrid<SoilData>(10, 10);

		public EasyGrid<SoilData> ShowGrid => mShowGrid;
		
		public TileBase Pen;
		
		void Start()
		{
			// initEasyGrid
			// initMShowGrid();
			
			mShowGrid.ForEach((x, y, data) =>
			{
				if (data!=null)
				{
					Tilemap.SetTile(new Vector3Int(x,y),Pen);
				}	
			});
		}

		private void initMShowGrid()
		{
			mShowGrid.ForEach(((x, y, data) => { mShowGrid[x, y] = new SoilData();}));
		}

	}
}
