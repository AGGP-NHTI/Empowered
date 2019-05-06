using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RangerClass : PlayerPawn
{
    public float MovementSpeed = 14;
    public float RotationSpeed = 280;

    public GameObject Stab;
    public GameObject StabPoint;
    public GameObject StabPoint2;
    public GameObject Arrow;
    public GameObject BowPoint;
    public float ChargeStab = 5;

    private float CooldownTime0;
    private float CooldownTime1;
    private float CooldownTime2;
    public float cooldownPeriod0 = 1.0f;
    public float cooldownPeriod1 = 17.0f;
    public float cooldownPeriod2 = 37.0f;

    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    Rigidbody rb;

    new void Start()
    {
        rb = GetComponent<Rigidbody>();
        IgnoresDamage = false;
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    private void Update()
    {
        if (RangerHealth <= 0)
        {
            Destroy(gameObject);
        }
        CooldownTime0 = Time.time + cooldownPeriod0;
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
            rb.AddForce(transform.forward * ChargeStab);
            GameObject Eviscerate1 = Instantiate(Stab, StabPoint.transform.position, StabPoint.transform.rotation);
            GameObject Eviscerate2 = Instantiate(Stab, StabPoint2.transform.position, StabPoint2.transform.rotation);
        }
    }

    public override void Fire2(bool value)
    {
        
        if(CooldownTime1 <= Time.time)
        {
            GameObject PiercingBolt = Instantiate(Arrow, BowPoint.transform.position, BowPoint.transform.rotation);
        }
    }
    public override void Fire3(bool value)
    {
        if(CooldownTime2 <= Time.time)
        {
            float Cloaktimer = 14.0f;
            if (IgnoresDamage == false && Cloaktimer == 14.0f)
            {
                IgnoresDamage = true;
                Cloaktimer -= Time.deltaTime;
                if (IgnoresDamage = true && Cloaktimer == 0.0f)
                {
                    IgnoresDamage = false;
                }
            }
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