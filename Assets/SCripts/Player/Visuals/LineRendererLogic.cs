using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class LineRendererLogic : MonoBehaviour
{

    private LineRenderer TargetLine;
    private Vector2 startPoint;
    public void setStartPoint(Vector2 start)
    {
        startPoint = start;
    }
    //TODO: Use dotween to make small startup for the aiming line
    private void Awake()
    {
        TargetLine = GetComponent<LineRenderer>();
        
    }
    private void Start()
    {
        this.enabled = false;
    }
    private void OnEnable()
    {
        TargetLine.enabled = true;
    }

    private void OnDisable()
    {
        TargetLine.enabled = false;
    }

    private void LateUpdate()
    {
        var targetDirection = (Vector2)Input.mousePosition - startPoint;
        TargetLine.SetPosition(1, targetDirection);
        TargetLine.SetPosition(0, transform.position);
    }
}
