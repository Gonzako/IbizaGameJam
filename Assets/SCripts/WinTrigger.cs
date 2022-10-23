using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class WinTrigger : MonoBehaviour
{
    private bool enableWin = false;
    public GameEvent OnPlayerPickupGold;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name + " passed by");
        if (enableWin)
        {
            OnPlayerPickupGold.Raise();
        }
    }

    public void EnableWin()
    {
        enableWin = true;
    }
}
