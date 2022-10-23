using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class ArcherProjectileLogic : MonoBehaviour
{
    public int damage = 5;
    public float arcPower = 2f;
    public float travelTime = 0.2f;
    //public ArcherProjectileLogic TargetProjectile;
    public UnityEvent<BaseAILogic> OnProjectileLand = new UnityEvent<BaseAILogic>();
    private Transform objective;
    private Health toDamage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTarget(BaseAILogic target)
    {
        toDamage = target.GetComponent<Health>();
        objective = target.transform.parent.GetComponentInChildren<SpriteRenderer>().transform;
        var t = transform.DOJump(objective.position+Random.insideUnitSphere*0.2f, arcPower, 1, travelTime).OnComplete(DamageTarget);
    }

    private void DamageTarget()
    {
        toDamage.RecieveDamage(damage);
        OnProjectileLand?.Invoke(toDamage.GetComponent<BaseAILogic>());
    }
}
