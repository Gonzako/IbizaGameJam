using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelSingleton : MonoBehaviour
{
    public static LevelSingleton instance;
    public Grid EnviromentGrid;
    public Tilemap MapCollision;
    
    private void Awake()
    {
        instance = this;
    }

    private void OnDisable()
    {
        instance = null;
    }
}
