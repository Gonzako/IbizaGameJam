using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerAI : MonoBehaviour
{
    [HideInInspector]
    public Vector3 spawnPoint;
    private Grid Enviroment;
    private Vector3Int CurrentPosition;
    [SerializeField]
    private Transform visuals;
    [SerializeField]
    private Transform logic;

    // Start is called before the first frame update
    void OnEnable()
    {
        Enviroment = LevelSingleton.instance.EnviromentGrid;
        CurrentPosition = Enviroment.WorldToCell(spawnPoint);
        visuals.position = spawnPoint;
        logic.position = Enviroment.CellToWorld(CurrentPosition);
    }

}
