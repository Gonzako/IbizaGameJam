using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPathFollow : MonoBehaviour
{
    
    
    public PathCreator LevelPath;
    [Range(0.01f,5)]
    public float Speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = LevelPath.path.GetPointAtTime(Time.time*Speed);
        transform.up = LevelPath.path.GetDirection(Time.time * Speed);
    }
}
