using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAIAnimation : MonoBehaviour
{
    private ArcherAILogic brain;

    void Awake()
    {
        brain = transform.parent.GetComponentInChildren<ArcherAILogic>();
    }

    private void OnEnable()
    {
        brain.OnUnitAttack += Brain_OnUnitAttack;
    }

    private void OnDisable()
    {
        brain.OnUnitAttack += Brain_OnUnitAttack;
    }


    private void Brain_OnUnitAttack(Transform arg1, Transform arg2)
    {
        GetComponentInChildren<Animator>().Play("Shoot");
        Debug.Log("is this working?");
    }

}
