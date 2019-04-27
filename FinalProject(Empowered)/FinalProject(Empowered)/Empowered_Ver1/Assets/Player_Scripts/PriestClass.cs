using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PriestClass : PlayerPawn
{
    public float MovementSpeed = 15;
    public float RotationSpeed = 268;
    public GameObject Slash;
    public GameObject attackpoint;


    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        if (KnightHealth <= 0)
        {
            Destroy(gameObject);
        }
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
        GameObject spam = Instantiate(Slash, attackpoint.transform.position, attackpoint.transform.rotation);
    }

    public override void Fire2(bool value)
    {

    }
    public override void Fire3(bool value)
    {

    }
    public override void Fire4(bool value)
    {

    }
}