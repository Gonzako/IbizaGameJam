using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelSingleton : MonoBehaviour
{
    public static LevelSingleton instance;
    public Grid EnviromentGrid;
    public Tilemap MapCollision;
    public Vector2Int PickupCell;
    public Vector2Int GoldPoint;
    private List<BaseAILogic> PlayerAis = new List<BaseAILogic>();
    private List<BaseAILogic> EnemyAis = new List<BaseAILogic>();

    private Vector3Int[,] spots;
    private BoundsInt bounds;
    private Astar Pathfinding;
    private void Awake()
    {
        instance = this;
        MapCollision.CompressBounds();
        bounds = MapCollision.cellBounds;
        PrepareGrid();
        Pathfinding = new Astar(spots, bounds.size.x, bounds.size.y);
        
    }

    public void PrepareGrid()
    {
        spots = new Vector3Int[bounds.size.x, bounds.size.y];
        for (int x = bounds.xMin, i = 0; i < (bounds.size.x); x++, i++)
        {
            for (int y = bounds.yMin, j = 0; j < (bounds.size.y); y++, j++)
            {
                if (MapCollision.HasTile(new Vector3Int(x, y, 0)))
                {
                    spots[i, j] = new Vector3Int(x, y, 0);
                }
                else
                {
                    spots[i, j] = new Vector3Int(x, y, 1);
                }
            }
        }
    }
 
    private void OnDestroy()
    {
        instance = null;
    }

    public List<Spot> GetPathTowardsPoint(Vector2Int Start, Vector2Int Target)
    {
        return Pathfinding.CreatePath(spots, Start, Target, 1000);
    }

    public void AddAIToLevel(BaseAILogic target)
    {
        if (target.IsForPlayer)
            PlayerAis.Add(target);
        else
            EnemyAis.Add(target);
    }
}
