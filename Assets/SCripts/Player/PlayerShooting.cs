using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{


    public BaseShootable currentShoot;
    
    // Start is called before the first frame update
    public void Shoot(Vector2 DirectionWithMagnitude)
    {
        currentShoot.HoldingTransform.up = DirectionWithMagnitude;
        currentShoot.OnShoot(DirectionWithMagnitude.magnitude);
        currentShoot = null;
    }

    public void SetShootable(BaseShootable target)
    {
        currentShoot = target;

    }
    private void LateUpdate()
    {
        if (currentShoot is null)
        {
            return;
        }
        //This line may be replaced by animations, etc
        currentShoot.HoldingTransform.transform.position = this.transform.position;
    }


   

}

public interface IShootable
{
    public Transform HoldingTransform { get; }
    public int GetWeight { get; }
    public void OnShoot(float strenght);

}