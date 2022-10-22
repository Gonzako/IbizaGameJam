using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Events;
using DG.Tweening;
public class AILogic : MonoBehaviour
{
    public float movementTime = 0.4f;
    public UnityEvent<Vector3> OnStartMoving;
    private Vector3Int cell;
    private Grid enviroment;
    private Tilemap collision;


    private void Start()
    {
        enviroment = LevelSingleton.instance.EnviromentGrid;
        cell = enviroment.WorldToCell(transform.position);
        collision = LevelSingleton.instance.MapCollision;
        StartCoroutine(WhatDoNext());
    }

    //Fill this with attack logic
    IEnumerator WhatDoNext()
    {

        yield return new WaitForSeconds(Random.Range(0.2f,1));

        StartCoroutine(MoveRoutine(AdjacentEmptyCell()));
    }

    IEnumerator MoveRoutine(Vector3Int adjacentCell)
    {
        OnStartMoving.Invoke(enviroment.CellToWorld(adjacentCell));
        cell = adjacentCell;
        transform.position = adjacentCell;
        yield return new WaitForSeconds(movementTime);
        StartCoroutine(WhatDoNext());
    }

    private Vector3Int AdjacentEmptyCell()
    {
        Vector3Int targetCell;
        do
        {
            targetCell = cell;
            targetCell.x += Random.Range(-1, 2);
            targetCell.y += Random.Range(-1, 2);

            //To see if cell is ocuppied here
        } while (!checkIfCellThere(targetCell));
        return targetCell;
    }

    private bool checkIfCellThere(Vector3Int cell)
    {
        var target = collision.GetTile(cell);
        if(target is null)
        {
            return false;
        }

        return true;
    }


}
