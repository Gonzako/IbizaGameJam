using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class PlayerShooting : MonoBehaviour
{
    public GameEvent OnPlayerRanOut; 

    public BaseShootable currentShoot;

    private void Awake()
    {
        currentShoot = Instantiate(LevelSingleton.instance.SpawnableAis[0]);
        LevelSingleton.instance.SpawnableAis.RemoveAt(0);
    }

    // Start is called before the first frame update
    public void Shoot(Vector2 DirectionWithMagnitude)
    {
        currentShoot.HoldingTransform.up = DirectionWithMagnitude;
        currentShoot.OnShoot(DirectionWithMagnitude.magnitude);
        currentShoot = null;
        if(LevelSingleton.instance.SpawnableAis.Count == 0)
        {
            OnPlayerRanOut.Raise();
            return;
        }
        currentShoot = Instantiate(LevelSingleton.instance.SpawnableAis[0]);
        LevelSingleton.instance.SpawnableAis.RemoveAt(0);

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