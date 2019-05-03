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

    public float ForwardBite = 5;

    public Vector3 Fly;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    Rigidbody rb;

    new void Start()
    {
        rb = GetComponent<Rigidbody>();
        IgnoresDamage = false;
        Fly = new Vector3(0.0f, 2.0f, 0.0f);
    }
    void OnCollisionStay()
    {
        isGrounded = true;
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
        rb.AddForce(transform.forward * ForwardBite);
        GameObject Bite = Instantiate(Mouth, MouthPoint.transform.position, MouthPoint.transform.rotation);
    }
    public override void Fire3(bool value)
    {
        float Scalestimer = 10.0f;
        if (IgnoresDamage == false && Scalestimer == 10.0f)
        {
            IgnoresDamage = true;
            Scalestimer -= Time.deltaTime;
            if (IgnoresDamage = true && Scalestimer == 0.0f)
            {
                IgnoresDamage = false;
            }
        }
    }
    public override void Fire4(bool value)
    {
        rb.AddForce(Fly * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }
    public override void Fire5(bool value)
    {
        
    }
    public override void Fire6(bool value)
    {
        GameObject Claw = Instantiate(Flame, FlamePoint.transform.position, FlamePoint.transform.rotation);
    }
}
