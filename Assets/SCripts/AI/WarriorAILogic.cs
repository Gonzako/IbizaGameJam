using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class WarriorAILogic : BaseAILogic
{
    //First transform is attacker, second transform is attacked
    public event Action<Transform, Transform> OnUnitAttack = null;
    public float attackDowntime = 0.5f;
    public int attackDamage = 10;
    private WarriorAttackAnimation attackEvent;
    protected override IEnumerator WhatDoNext()
    {
        int enemyCount;
        if (this.IsForPlayer)
        {
            enemyCount = LevelSingleton.instance.EnemyAis.Count;
        }
        else
        {
            enemyCount = LevelSingleton.instance.PlayerAis.Count;
        }

        if (enemyCount>0)
        {
            var targetEnemy = FindNearestEnemy();
            if (Vector3Int.Distance(targetEnemy.cell, cell) < 1.5f)
            {
                OnUnitAttack?.Invoke(transform, targetEnemy.gameObject.transform);
                //Debug.Log(transform.parent + " attacked " + targetEnemy.gameObject.transform.parent);
                yield return new WaitForSeconds(attackDowntime);
                StartCoroutine(WhatDoNext());
                yield break;
            }
            else
            {
                var path = LevelSingleton.instance.GetPathTowardsPoint((Vector2Int)targetEnemy.cell, (Vector2Int)cell);
                yield return StartCoroutine(MoveRoutine(new Vector3Int(path[1].X,path[1].Y)));
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


    private void OnEnable()
    {
        attackEvent = transform.parent.GetComponentInChildren<WarriorAttackAnimation>();
        attackEvent.OnReachEnemy += AttackEvent_OnReachEnemy;
    }

    private void AttackEvent_OnReachEnemy(Transform obj)
    {
        //Debug.Log("Attacked!");
        obj.GetComponent<Health>().RecieveDamage(attackDamage);
    }

    private void OnDisable()
    {
        attackEvent.OnReachEnemy -= AttackEvent_OnReachEnemy;
    }
}
