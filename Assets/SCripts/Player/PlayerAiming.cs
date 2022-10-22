using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using ScriptableObjectArchitecture;

public class PlayerAiming : MonoBehaviour
{
    private Vector2 startPoint;
    private bool enableShoot = false;

    public Vector2GameEvent OnStartAiming = null;
    public GameEvent OnCancelAiming = null;
    public Vector2GameEvent OnHandleShoot = null;

    public void HandleShoot(InputAction.CallbackContext ctx)
    {
        if(ctx.started) {
            Debug.Log("Grabbing start point to use as aimpoint");
            startPoint = Input.mousePosition;
            enableShoot = false;
            OnStartAiming.Raise(startPoint);
        }
        if (ctx.performed)
        {
            Debug.Log("Held too little do nothing");
            startPoint = Vector2.zero;
            OnCancelAiming.Raise();
        }
        if (ctx.canceled)
        {
            Debug.Log("Player held long enough to be able to shoot");
            enableShoot = true;
        }
    }

    public void HandleShootRelease(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed)
        {
            return;
        }
        
        if (!enableShoot)
        {
            return;
        }
        var targetPoint = CalcHelpers.GetPlayerShoot(startPoint);
        OnHandleShoot.Raise(targetPoint);
    }
}
