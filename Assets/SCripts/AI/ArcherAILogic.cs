using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ArcherAILogic : BaseAILogic
{
    public event Action<Transform, Transform> OnUnitAttack = null;
    [Range(0, 5)]
    public int attackRange = 3;
    public float attackDowntime = 0.6f;
    public ArcherProjectileLogic ProjectileToSpawn;
    public Transform shootPoint;
    private ArcherThrowAnimEvent attackEvent;
    private BaseAILogic tempEnemy;

    private void OnEnable()
    {
        attackEvent = transform.parent.GetComponentInChildren<ArcherThrowAnimEvent>();
        attackEvent.OnRecieveShootCommand += AttackEvent_OnRecieveShootCommand;
    }

    private void OnDisable()
    {
        attackEvent.OnRecieveShootCommand -= AttackEvent_OnRecieveShootCommand;
    }

    protected override IEnumerator WhatDoNext()
    {
        tempEnemy = null;
        int enemyCount;
        if (this.IsForPlayer)
        {
            enemyCount = LevelSingleton.instance.EnemyAis.Count;
        }
        else
        {
            enemyCount = LevelSingleton.instance.PlayerAis.Count;
        }

        if (enemyCount > 0)
        {
            var targetEnemy = FindNearestEnemy();
            if (Vector3Int.Distance(targetEnemy.cell, cell) < (attackRange+0.5f))
            {
                tempEnemy = targetEnemy;
                OnUnitAttack?.Invoke(transform, targetEnemy.gameObject.transform);
                
                //Debug.Log(transform.parent + " attacked " + targetEnemy.gameObject.transform.parent);
                yield return new WaitForSeconds(attackDowntime);
                StartCoroutine(WhatDoNext());
                yield break;
            }
            else
            {
                var path = LevelSingleton.instance.GetPathTowardsPoint((Vector2Int)targetEnemy.cell, (Vector2Int)cell);
                if(path is null)
                    yield break;
                yield return StartCoroutine(MoveRoutine(new Vector3Int(path[1].X, path[1].Y)));
                StartCoroutine(WhatDoNext());
                yield break;
            }
        }
        Vector3Int randomMove;
        do
        {
            randomMove = cell + new Vector3Int(Random.Range(-1, 2), Random.Range(-1, 2));

        } while (!LevelSingleton.instance.MapCollision.HasTile(randomMove));
        yield return StartCoroutine(MoveRoutine(randomMove));
        StartCoroutine(WhatDoNext());
    }

    private void AttackEvent_OnRecieveShootCommand()
    {
        if(tempEnemy is null)
        {
            return;
        }

        var proj = Instantiate(ProjectileToSpawn, shootPoint.position, Quaternion.identity);
        proj.SetTarget(tempEnemy);

    }


}
