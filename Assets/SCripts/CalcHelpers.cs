using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CalcHelpers
{
    public static Vector2 GetPlayerShoot(Vector2 startPoint)
    {
        var targetDirection = (Vector2)Input.mousePosition - startPoint;
        //Width and size of the camera set as raw numbers (for now)
        var screenAwareDirection = new Vector2(targetDirection.x * 15f / Screen.currentResolution.width, targetDirection.y * 8.435f / Screen.currentResolution.height);

        return screenAwareDirection;
    }
}
