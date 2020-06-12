using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

public class TileMap
{

    private WorldGrid<TilemapObject> grid;

    public TileMap(int width, int height, float cellSize, Vector3 originPos)
    {
        grid = new WorldGrid<TilemapObject>(width, height, cellSize, originPos, (WorldGrid<TilemapObject> g, int x, int y) => new TilemapObject(g, x, y));
    }

    public void SetTilemapSprite(Vector3 worldPos, TilemapObject.TilemapSprite sprite)
    {
        Debug.Log("DID WE GET HERE??");
        TilemapObject tObj = grid.getAt(worldPos);
        if (tObj != null)
        {
            Debug.Log("set " + tObj.getXY() + "  to " + sprite.ToString());
            tObj.SetTilemapSprite(sprite);
        }
    }

    public void SetTileRenderer(TileRenderManager tileRenderer)
    {
        tileRenderer.SetGrid(grid);
    }

    public class TilemapObject
    {
        public enum TilemapSprite
        {
            None, 
            Stone
        }

        private WorldGrid<TilemapObject> grid;
        private int x, y;
        private TilemapSprite floorSprite;
       


        public TilemapObject(WorldGrid<TilemapObject> grid, int x, int y)
        {
            this.grid = grid;
            this.x = x;
            this.y = y;
        }


        public Vector2Int getXY()
        {
            return new Vector2Int(this.x, this.y);
        }
        public void SetTilemapSprite(TilemapSprite floorTiles)
        {
            this.floorSprite = floorTiles;
            grid.TriggerGridObjectChanged(x, y);
        }

        public TilemapSprite GetTilemapSprite()
        {
            return floorSprite;
        }

        



    }
}
