using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Health : MonoBehaviour
{
    public int MaxHealthPoints = 100;
    [SerializeField] private SpriteRenderer sprite;
    public UnityEvent<int> OnRecieveDamage = new UnityEvent<int>();
    public UnityEvent OnDeath = new UnityEvent();
    private int currentHealth;
   

    private void Start()
    {
        currentHealth = MaxHealthPoints;
    }

    public void RecieveDamage(int damageAmount)
    {

        currentHealth -= damageAmount;

        if (currentHealth > 0)
        {
            OnRecieveDamage.Invoke(currentHealth);
        }

        else
        {
            OnDeath.Invoke();
        }
    }

    public void Die()
    {


        Debug.Log("DIE");
        Vector3 finalRotation = new Vector3(0, 0, 90);

        var T = GetComponent<BaseAILogic>();
        Debug.Log(T);
        T.enabled = false;
        sprite.transform.DORotate(finalRotation, .5f);
        sprite.DOFade(0, 1).OnComplete(Destroy);
       
    }

    private void Destroy()
    {
        Destroy(transform.parent.gameObject);
    }
}
