using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSlash : Class
{
    public float damageAmount = 35.0f;

    public float lifetime = 2f;
    Rigidbody rb;

    void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();

    }

    private void Update()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        Class OtherClass = other.gameObject.GetComponentInParent<Class>();
        if (OtherClass )
        {
            OtherClass.TakeDamage(this, damageAmount, new DamageEventInfo(typeof(AttackDamageType)), Owner);
        }
        OnDeath();
    }

    public virtual void OnDeath()
    {
        Destroy(gameObject);
    }
}
