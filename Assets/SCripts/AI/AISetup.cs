using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AISetup : MonoBehaviour
{
    private Grid Enviroment;
    private Vector3Int CurrentPosition;
    [SerializeField]
    private Transform visuals;
    [SerializeField]
    private Transform logic;

    public UnityEvent<Vector3> OnUnitSplash = new UnityEvent<Vector3>();

    // Start is called before the first frame update
    void OnEnable()
    {

        Enviroment = LevelSingleton.instance.EnviromentGrid;
        CurrentPosition = Enviroment.WorldToCell(transform.position);
        visuals.localPosition = Vector3.zero;
        logic.position = Enviroment.CellToWorld(CurrentPosition);
        var AIlog = logic.GetComponent<BaseAILogic>();
        AIlog.SetCell(CurrentPosition);
        if (!LevelSingleton.instance.MapCollision.HasTile(CurrentPosition))
        {
            OnUnitSplash.Invoke(transform.position);
            Destroy(this.gameObject, 0.1f);
        }
        else
        {
            LevelSingleton.instance.AddAIToLevel(AIlog);
        }
    }

}
