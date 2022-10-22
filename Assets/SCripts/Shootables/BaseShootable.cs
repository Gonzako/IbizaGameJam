using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using ScriptableObjectArchitecture;

public class BaseShootable : MonoBehaviour, IShootable
{
    public int GetWeight => this.Weight;
    public FloatVariable StrengthMultiplier;
    public Transform HoldingTransform => this.transform;

    [SerializeField]
    private int Weight = 1;

    public UnityEvent OnThisShoot = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnShoot(float strength)
    {
        strength = Mathf.Clamp(strength, 0, 3);
        Debug.Log("Test shoot, you shouldnt be using this in production");
        var targetPoint = transform.position + transform.up * -strength * StrengthMultiplier.Value;
        transform.DOMove(targetPoint, 1).SetEase(Ease.OutCirc);

        //
    }
}
