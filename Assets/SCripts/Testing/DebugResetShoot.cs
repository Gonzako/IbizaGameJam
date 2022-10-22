using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugResetShoot : MonoBehaviour
{
    public BaseShootable testShootable;
    public PlayerShooting playerShooter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            playerShooter.SetShootable(testShootable);
        }
    }
}
