using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class WorldGrid <TGridObject>
{

    public event EventHandler<OnGridChange> OnGridObjectChange;

    public class OnGridChange : EventArgs
    {
        public int x;
        public int y;
    }

    private int width;
    private int height;
    private TGridObject[,] gridArray;
    private float cellSize;
    private Vector3 origin;

    public WorldGrid(int w, int h, float cs, Vector3 origin, Func<WorldGrid<TGridObject>, int, int, TGridObject> createGridObject)
    {
        this.width = w;
        this.height = h;
        this.cellSize = cs;
        this.origin = origin;

        gridArray = new TGridObject[width, height];
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        for (int x=0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                Debug.DrawLine(getWorldPos(x, y), getWorldPos(x + 1, y), Color.white, 100f);
                Debug.DrawLine(getWorldPos(x, y), getWorldPos(x, y + 1), Color.white, 100f);
                gridArray[x, y] = createGridObject(this, x, y);

            }

        }
        Debug.DrawLine(getWorldPos(0, height), getWorldPos(width, height), Color.red, 100f);

    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }

    public float GetCellSize()
    {
        return cellSize;
    }
    public Vector3 getWorldPos(int x, int y)
    {
        return new Vector3(x, y) * cellSize + origin;
    }

    private Vector2Int GetXYFromWorldPos(Vector3 worldPos)
    {
        int x = Mathf.FloorToInt((worldPos - origin).x / cellSize);
        int y = Mathf.FloorToInt((worldPos - origin).y / cellSize);
        return new Vector2Int(x, y);
    }

    public void setAt(int x, int y, TGridObject val)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = val;
            if (OnGridObjectChange != null)
            {
                OnGridObjectChange(this, new OnGridChange { x = x, y = y });
            }
        }
    }

    public void setAt(Vector3 worldPos, TGridObject val)
    {
        Vector2Int xy = GetXYFromWorldPos(worldPos);
        if (xy.x >= 0 && xy.y >= 0 && xy.x < width && xy.y < height)
        {
            this.setAt(xy.x, xy.y, val);
        }
            
    }
    public TGridObject getAt(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
            return gridArray[x, y];
        else
            return default(TGridObject);
    }
    public TGridObject getAt(Vector3 worldPos)
    {
        Vector2Int xy = GetXYFromWorldPos(worldPos);
        return getAt(xy.x, xy.y);
    }

    public void TriggerGridObjectChanged(int x, int y)
    {
        if (OnGridObjectChange != null)
        {
            OnGridObjectChange(this, new OnGridChange { x = x, y = y });
        }
    }

}
