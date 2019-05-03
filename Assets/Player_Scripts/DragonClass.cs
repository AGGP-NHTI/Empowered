using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DragonClass : PlayerPawn
{
    public float MovementSpeed = 45;
    public float RotationSpeed = 450;


    public GameObject Slash;
    public GameObject SlashPoint1;
    public GameObject SlashPoint2;
    public GameObject SlashPoint3;
    public GameObject SlashPoint4;
    public GameObject SlashPoint5;

    public GameObject Flame;
    public GameObject FlamePoint;

    public GameObject Mouth;
    public GameObject MouthPoint;

    

    Rigidbody rb;
    new void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        if (DragonHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DragonPassive()
    {

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
        GameObject Claw1 = Instantiate(Slash, SlashPoint1.transform.position, SlashPoint1.transform.rotation);
        GameObject Claw2 = Instantiate(Slash, SlashPoint2.transform.position, SlashPoint2.transform.rotation);
        GameObject Claw3 = Instantiate(Slash, SlashPoint3.transform.position, SlashPoint3.transform.rotation);
        GameObject Claw4 = Instantiate(Slash, SlashPoint4.transform.position, SlashPoint4.transform.rotation);
        GameObject Claw5 = Instantiate(Slash, SlashPoint5.transform.position, SlashPoint5.transform.rotation);
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
    public override void Fire5(bool value)
    {
        
    }
    public override void Fire6(bool value)
    {
        GameObject Claw = Instantiate(Flame, FlamePoint.transform.position, FlamePoint.transform.rotation);
    }
}
