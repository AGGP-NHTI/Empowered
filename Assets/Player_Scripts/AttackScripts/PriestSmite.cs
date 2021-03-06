﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestSmite : Class
{
    public float damageAmount = 35.0f;
    public float movementSpeed = 50f;
    public float lifetime = 5f;
    Rigidbody rb;

    void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();

        rb.velocity = transform.forward * movementSpeed;


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
