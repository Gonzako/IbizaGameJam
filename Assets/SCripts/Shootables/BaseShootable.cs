using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseShootable : MonoBehaviour, IShootable
{
    public int GetWeight => this.Weight;

    public Transform HoldingTransform => this.transform;

    [SerializeField]
    private int Weight = 1;

    public UnityEvent OnThisShoot = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnShoot(float strength)
    {
        Debug.Log("Test shoot, you shouldnt be using this in production");

    }
}
