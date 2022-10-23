using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThiefAILogic : BaseAILogic
{
    public UnityEvent OnPickupGold;
    public UnityEvent OnReachHarbour;
    protected override IEnumerator WhatDoNext()
    {

        yield return StartCoroutine(PathFindRoutine(LevelSingleton.instance.GoldPoint));

        OnPickupGold.Invoke();

        yield return StartCoroutine(PathFindRoutine(LevelSingleton.instance.PickupCell));

        OnReachHarbour.Invoke();
    }

}
