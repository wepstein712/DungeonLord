using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private TileRenderManager TRM;
    TileMap tiles;
    // Start is called before the first frame update
    void Start()
    {
        tiles = new TileMap(5, 5, 1f, Vector3.zero);

        tiles.SetTileRenderer(TRM);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (tiles == null) Debug.Log("ITS NULL??");
            tiles.SetTilemapSprite(pos, TileMap.TilemapObject.TilemapSprite.Stone);
        }
    }
}
