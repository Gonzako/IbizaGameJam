using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeReference]
    public IShootable currentShoot;
    // Start is called before the first frame update
    public void Shoot(Vector3 Direction)
    {

    }
    
}

public interface IShootable
{
    public int GetWeight { get; }
    public void OnShoot();

}