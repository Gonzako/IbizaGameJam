using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShootable : MonoBehaviour, IShootable
{
    public int GetWeight => this.Weight;

    [SerializeField]
    private int Weight = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnShoot()
    {
        Debug.Log("Test shoot, you shouldnt be using this in production");
    }
}
