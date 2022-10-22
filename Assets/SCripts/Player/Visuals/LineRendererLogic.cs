using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class LineRendererLogic : MonoBehaviour
{
    [Range(0f,20f)]
    public float MaximumLenght = 10;
    public bool Invert = true;
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
        var screenAwareDirection = CalcHelpers.GetPlayerShoot(startPoint);
        var currentMagnitude = screenAwareDirection.magnitude;
        //Debug.Log(currentMagnitude.ToString() + " " + screenAwareDirection.ToString());
        TargetLine.SetPosition(1, ((Invert ? -1 : 1)* screenAwareDirection.normalized*Mathf.Clamp(currentMagnitude,0, MaximumLenght) +(Vector2)transform.position));
        TargetLine.SetPosition(0, transform.position);
    }
}
