﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Class
{

    public float damageAmount = 10.0f;
    public float movementSpeed = 20f;
    public float lifetime = 2f;
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
        if (OtherClass)
        {
            OtherClass.TakeDamage( this, damageAmount, new DamageEventInfo(typeof(AttackDamageType)), Owner);
        }
        OnDeath();
    }

    public virtual void OnDeath()
    {
        Destroy(gameObject);
    }

}