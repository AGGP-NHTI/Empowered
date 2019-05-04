using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightShield : Class
{
    public float damageAmount = 45.0f;

    KnightClass Knight;
    Rigidbody rb;

    void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Class OtherClass = other.gameObject.GetComponentInParent<Class>();
        if (OtherClass)
        {
            OtherClass.TakeDamage(this, damageAmount, new DamageEventInfo(typeof(AttackDamageType)), Owner);
        }
        Knight.BashRushPoint.SetActive(false);
    }

    
}
