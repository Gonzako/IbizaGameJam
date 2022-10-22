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
    public Vector3Int cell;
    private Tilemap collision;


    private void Start()
    {
        collision = LevelSingleton.instance.MapCollision;

        cell = collision.WorldToCell(transform.position);
        StartCoroutine(WhatDoNext());
    }

    public void SetCell(Vector3Int target)
    {
        cell = target;
    }

    //Fill this with attack logic
    IEnumerator WhatDoNext()
    {
        yield return null;
        StartCoroutine(PathFindRoutine(new Vector2Int(Random.Range(-10,10),Random.Range(-10,10))));
        //yield return new WaitForSeconds(Random.Range(0.2f,1));

        //StartCoroutine(MoveRoutine(AdjacentEmptyCell()));
    }

    IEnumerator MoveRoutine(Vector3Int adjacentCell)
    {
        OnStartMoving.Invoke(collision.CellToWorld(adjacentCell));
        cell = adjacentCell;
        transform.position = LevelSingleton.instance.MapCollision.CellToWorld(cell); 
        yield return new WaitForSeconds(movementTime);
        StartCoroutine(WhatDoNext());
    }

    IEnumerator PathFindRoutine (Vector2Int Target)
    {
        var Path = LevelSingleton.instance.GetPathTowardsPoint((Vector2Int)cell, Target);
        if(Path is null)
        {
            Debug.Log("Atascado");
            StartCoroutine(WhatDoNext());
            yield break;
        }
        for (int i = Path.Count-1; i >= 0; i--)
        {
            
            yield return new WaitForSeconds(0.1f);
            var targetSpot = Path[i];
            Debug.Log(targetSpot);
            cell = new Vector3Int(targetSpot.X, targetSpot.Y);
            OnStartMoving.Invoke(collision.CellToWorld(cell)+Vector3.one*0.5f);
            transform.position = collision.CellToWorld(cell);
            yield return new WaitForSeconds(movementTime);
        }
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
        return collision.HasTile(cell);

    }



}
