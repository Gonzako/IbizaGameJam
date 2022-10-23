using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WarriorAttackAnimation : MonoBehaviour
{
    public event Action<Transform> OnReachEnemy;
    [SerializeField,Range(0.3f, 2f)]
    private float Distance = 0.5f;
    WarriorAILogic brain;
    // Start is called before the first frame update
    void Awake()
    {
        brain = transform.parent.GetComponentInChildren<WarriorAILogic>();
    }

    private void OnEnable()
    {
        brain.OnUnitAttack += Brain_OnUnitAttack;       
    }


    private void OnDisable()
    {
        brain.OnUnitAttack += Brain_OnUnitAttack;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void Brain_OnUnitAttack(Transform Atacante, Transform Objetivo)
    {
        var originalPos = transform.position;
        var attackSequence = DOTween.Sequence();
        var attackPoint = Vector3.zero;
        //attackPoint =  Objetivo.parent.GetComponentInChildren<AIVisualMove>().transform.position;
        attackPoint = Objetivo.parent.GetComponentInChildren<AIVisualMove>().transform.position-transform.position;
        attackPoint = attackPoint.normalized * Distance;
        attackSequence.Append(transform.DOMove(transform.position+attackPoint, 0.1f).OnComplete(()=>OnReachEnemy.Invoke(Objetivo)));
        attackSequence.Append(transform.DOMove(originalPos, 0.3f));
    }

}
