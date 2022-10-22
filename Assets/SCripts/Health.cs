using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int MaxHealthPoints = 100;
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

        if(currentHealth > 0)
        {
            OnRecieveDamage.Invoke(currentHealth);
        }
    }
}
