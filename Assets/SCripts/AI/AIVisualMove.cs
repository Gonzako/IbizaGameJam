using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AIVisualMove : MonoBehaviour
{

    public float movementTime = 0.4f;
    private Tween moveTween;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToPosition(Vector3 target)
    {
        var targetPos = target + Random.insideUnitSphere*0.5f;
        targetPos.z = 0;
        moveTween?.Complete();
        moveTween = transform.DOMove(targetPos, movementTime).SetEase(Ease.Linear);
    }
}
