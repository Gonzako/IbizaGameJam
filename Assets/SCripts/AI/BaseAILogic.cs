using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Events;
using DG.Tweening;
public class BaseAILogic : MonoBehaviour
{
    public float movementTime = 0.4f;
    public UnityEvent<Vector3> OnStartMoving;
    public Vector3Int cell;
    public int damage = 50;
    public bool IsForPlayer { get => FromPlayer; }
    [SerializeField]
    private bool FromPlayer = true;
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
    protected virtual IEnumerator WhatDoNext()
    {

        //
        yield return StartCoroutine(PathFindRoutine(new Vector2Int(Random.Range(-10,10),Random.Range(-10,10))));
        //yield return StartCoroutine(PathFindRoutine(LevelSingleton.instance.PickupCell));
        //yield return new WaitForSeconds(Random.Range(0.2f,1));

        //StartCoroutine(MoveRoutine(AdjacentEmptyCell()));
        StartCoroutine(WhatDoNext());
    }

    protected IEnumerator MoveRoutine(Vector3Int adjacentCell)
    {
        OnStartMoving.Invoke(collision.CellToWorld(adjacentCell));
        cell = adjacentCell;
        transform.position = LevelSingleton.instance.MapCollision.CellToWorld(cell); 
        yield return new WaitForSeconds(movementTime);
    }

    protected virtual IEnumerator PathFindRoutine (Vector2Int Target)
    {
        var Path = LevelSingleton.instance.GetPathTowardsPoint((Vector2Int)cell, Target);
        if(Path is null)
        {
            yield break;
        }
        for (int i = Path.Count-1; i >= 0; i--)
        {
            
            yield return new WaitForSeconds(0.1f);
            var targetSpot = Path[i];
            //Debug.Log(targetSpot);
            //OnStartMoving.Invoke(collision.CellToWorld(cell)+Vector3.one*0.5f);
            //transform.position = collision.CellToWorld(cell);
            yield return StartCoroutine(MoveRoutine(new Vector3Int(targetSpot.X, targetSpot.Y)));
        }
    }
    
    protected BaseAILogic FindNearestEnemy()
    {
        if (FromPlayer)
        {

            return FindNearest(LevelSingleton.instance.EnemyAis);
        }
        else
        {
            return FindNearest(LevelSingleton.instance.PlayerAis);
        }


    }

    private BaseAILogic FindNearest(List<BaseAILogic> target)
    {
        float distance = float.MaxValue;
        int desiredIndex = 0;
        for (int i = 0; i < target.Count; i++)
        {
            float currDist = Vector3Int.Distance(target[i].cell, cell);
            if (currDist < distance)
            {
                desiredIndex = i;
                distance = currDist;
            }
        }
        return target[desiredIndex];
    }
}
