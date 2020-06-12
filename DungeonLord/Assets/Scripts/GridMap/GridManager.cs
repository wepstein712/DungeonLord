using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    // Start is called before the first frame update

    private WorldGrid<int> grid;
    void Start()
    {
        //grid = new WorldGrid<int>(3, 3, 3, transform.position, () => 0);

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(grid.getAt(pos));
            grid.setAt(pos, grid.getAt(pos) + 1);
            Debug.Log(grid.getAt(pos));

        }
    }





}
