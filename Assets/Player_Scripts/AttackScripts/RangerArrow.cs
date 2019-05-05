using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerArrow : Class
{

    DragonClass drag;
    public float damageAmount = 50.0f;
    public float movementSpeed = 35f;
    public float lifetime = 3f;
    Rigidbody rb;

    void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();

        rb.velocity = transform.forward * movementSpeed;

        drag.IgnoresDamage = false;
    }

    private void Update()
    {
        rb.velocity = transform.forward * movementSpeed;
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        Class OtherClass = other.gameObject.GetComponentInParent<Class>();
        if (OtherClass && other.gameObject.tag == "Boss")
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
