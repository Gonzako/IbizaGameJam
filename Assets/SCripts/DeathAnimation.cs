using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DeathAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDeathAnim()
    {
        Vector3 finalRotation = new Vector3(0, 0, 90);
        transform.DORotate(finalRotation, .5f);
        GetComponent<SpriteRenderer>().DOFade(0, 1).OnComplete(Destroy);
    }

    private void Destroy()
    {
        Destroy(transform.parent.parent.gameObject);
    }
}
