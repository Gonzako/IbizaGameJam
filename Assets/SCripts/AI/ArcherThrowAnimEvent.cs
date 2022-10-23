using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherThrowAnimEvent : MonoBehaviour
{
    public event Action OnRecieveShootCommand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void throwProjectile()
    {
        OnRecieveShootCommand?.Invoke();

    }
}
