using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FindCellInClick : MonoBehaviour
{

    public Tilemap targetTilemap;
    public Grid testGrid;
    private Camera testCam;

    private void Start()
    {
        testCam = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Grid says it's cell "+testGrid.WorldToCell(testCam.ScreenToWorldPoint(Input.mousePosition)));
            Debug.Log("Tilemap says it's cell " + targetTilemap.WorldToCell(testCam.ScreenToWorldPoint(Input.mousePosition)));
        }
    }

}
