using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPathFollow : MonoBehaviour
{
    
    [HideInInspector]
    private PathCreator LevelPath;
    [Range(0.01f,5)]
    public float Speed = 1f;
    // Start is called before the first frame update
    private float tempTime = 0;
    void Awake()
    {
        LevelPath = FindObjectOfType<PathCreator>();
    }

    // Update is called once per frame
    void Update()
    {
        tempTime += Time.deltaTime*Speed;

        transform.position = LevelPath.path.GetPointAtTime(tempTime);
        transform.up = LevelPath.path.GetDirection(tempTime);
    }
}
