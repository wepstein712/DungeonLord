using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRenderManager : MonoBehaviour
{
    public struct TilemapSpriteUV
    {
        public TileMap.TilemapObject.TilemapSprite tileSprite;
        public Vector2Int uv00Px;
        public Vector2Int uv11Px;

    }

    private struct UVCoords
    {
        public Vector2 uv00;
        public Vector2 uv11;
    }

    [SerializeField] private TilemapSpriteUV[] tilemapSpriteUVArray;
    private WorldGrid<TileMap.TilemapObject> grid;
    private Mesh mesh;
    private bool updateMesh;
    private Dictionary<TileMap.TilemapObject.TilemapSprite, UVCoords> uvCoordsDict;

    private void Awake()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        Texture texture = GetComponent<MeshRenderer>().material.mainTexture;
        float textureWidth = texture.width;
        float textureHeight = texture.height;

        uvCoordsDict = new Dictionary<TileMap.TilemapObject.TilemapSprite, UVCoords>();

        foreach (TilemapSpriteUV tilemapSpriteUV in tilemapSpriteUVArray)
        {
            uvCoordsDict[tilemapSpriteUV.tileSprite] = new UVCoords
            {
                uv00 = new Vector2(tilemapSpriteUV.uv00Px.x / textureWidth, tilemapSpriteUV.uv00Px.y / textureHeight),
                uv11 = new Vector2(tilemapSpriteUV.uv11Px.x / textureWidth, tilemapSpriteUV.uv11Px.y / textureHeight),
            };
        }
    }

    public void SetGrid(WorldGrid<TileMap.TilemapObject> tGrid)
    {
        this.grid = tGrid;
        UpdateVisuals();

        grid.OnGridObjectChange += GridValueChange;

    }

    public void SetGrid(TileMap tilemap, WorldGrid<TileMap.TilemapObject> tGrid)
    {
        this.grid = tGrid;
        UpdateVisuals();

        grid.OnGridObjectChange += GridValueChange;
    }

    private void GridValueChange(object sender, WorldGrid<TileMap.TilemapObject>.OnGridChange e)
    {
        updateMesh = true;
    }

    private void LateUpdate()
    {
        if (updateMesh)
        {
            updateMesh = false;
            UpdateVisuals();
        }
    }

    private void UpdateVisuals()
    {
        MeshUtils.CreateEmptyMeshArrays(grid.GetWidth() * grid.GetHeight(), out Vector3[] vertices, out Vector2[] uv, out int[] triangles);

        int width = grid.GetWidth();
        int height = grid.GetHeight();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int index = x * grid.GetHeight() + y;
                Vector3 quadSize = new Vector3(1, 1) * grid.GetCellSize();

                TileMap.TilemapObject gridObject = grid.getAt(x, y);
                TileMap.TilemapObject.TilemapSprite tilemapSprite = gridObject.GetTilemapSprite();
                Vector2 gridUV00, gridUV11;
                if (tilemapSprite == TileMap.TilemapObject.TilemapSprite.None)
                {
                    gridUV00 = Vector2.zero;
                    gridUV11 = Vector2.zero;
                    quadSize = Vector3.zero;
                }
                else
                {
                    UVCoords uvCoords = uvCoordsDict[tilemapSprite];
                    gridUV00 = uvCoords.uv00;
                    gridUV11 = uvCoords.uv11;
                }

                MeshUtils.AddToMeshArrays(vertices, uv, triangles, index, grid.getWorldPos(x, y) + quadSize * .5f, 0f, quadSize, gridUV00, gridUV11);


            }
        }
    }

}

