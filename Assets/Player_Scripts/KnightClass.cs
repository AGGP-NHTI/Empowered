﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class KnightClass : PlayerPawn
{
    public float MovementSpeed = 14;
    public float RotationSpeed = 280;

    public GameObject Slash;
    public GameObject SlashPoint;
    public GameObject AirShield;
    public GameObject AirShieldPoint;
    public float ChargeAttack = 40;

    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    Rigidbody rb;
    new void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
    private void Update()
    {
        if (KnightHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionStay()
    {
        isGrounded = true;
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
        GameObject SwordSlash = Instantiate(Slash, SlashPoint.transform.position, SlashPoint.transform.rotation);
    }

    public override void Fire2(bool value)
    {
        rb.AddForce(transform.forward * ChargeAttack);
    }
    public override void Fire3(bool value)
    {
        GameObject AirShieldWall = Instantiate(AirShield, AirShieldPoint.transform.position, AirShieldPoint.transform.rotation);
    }
    public override void Fire4(bool value)
    {
        rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }
}