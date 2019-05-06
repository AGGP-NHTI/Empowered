﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MageClass : PlayerPawn
{
    public float MovementSpeed = 14;
    public float RotationSpeed = 280;

    public GameObject Fire;
    public GameObject FirePoint;
    public GameObject Lightning;
    public GameObject LightningPoint;
    public GameObject ArcaneShieldPoint;

    private float CooldownTime0;
    private float CooldownTime1;
    private float CooldownTime2;
    public float cooldownPeriod0 = 1.0f;
    public float cooldownPeriod1 = 19.0f;
    public float cooldownPeriod2 = 33.0f;

    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    Rigidbody rb;

    new void Start()
    {
        rb = GetComponent<Rigidbody>();
        ArcaneShieldPoint.SetActive(false);
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    private void Update()
    {
        if (MageHealth <= 0)
        {
            Destroy(gameObject);
        }

        CooldownTime1 = Time.time + cooldownPeriod1;
        CooldownTime2 = Time.time + cooldownPeriod2;
    }

    public override void Horizontal(float value)
    {
        if (Mathf.Abs(value) < .05)
        {
            return;
        }
        gameObject.transform.Rotate(0, (value * RotationSpeed * Time.deltaTime), 0);
    }

    public override void Vertical(float value)
    {
        if (Mathf.Abs(value) < .05)
        {
            rb.velocity = Vector3.zero;
            return;
        }
        rb.velocity = gameObject.transform.forward * value * MovementSpeed;
    }
    public override void Fire1(bool value)
    {
        if(CooldownTime0 <= Time.time)
        {
            GameObject FireBolt = Instantiate(Fire, FirePoint.transform.position, FirePoint.transform.rotation);
        }
    }

    public override void Fire2(bool value)
    {
        if(CooldownTime1 <= Time.time)
        {
            GameObject LightningBolt = Instantiate(Lightning, LightningPoint.transform.position, LightningPoint.transform.rotation);
        }
    }
    public override void Fire3(bool value)
    {
        if(CooldownTime2 <= Time.time)
        {
            ArcaneShieldPoint.SetActive(true);
        }
    }
    public override void Fire4(bool value)
    {
        if (isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        
    }

    
}