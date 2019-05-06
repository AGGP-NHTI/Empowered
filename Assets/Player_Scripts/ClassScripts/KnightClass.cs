using System.Collections;
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
    public GameObject BashRushPoint;
    public float ChargeAttack = 40;

    private float CooldownTime0;
    private float CooldownTime1;
    private float CooldownTime2;
    public float cooldownPeriod0 = 1.0f;
    public float cooldownPeriod1 = 13.0f;
    public float cooldownPeriod2 = 40.0f;

    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    Rigidbody rb;
    new void Start()
    {
        rb = GetComponent<Rigidbody>();
        BashRushPoint.SetActive(false);
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
    private void Update()
    {
        if (KnightHealth <= 0)
        {
            Destroy(gameObject);
        }

        CooldownTime1 = Time.time + cooldownPeriod1;
        CooldownTime2 = Time.time + cooldownPeriod2;
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
        if(CooldownTime0 <= Time.time)
        {
            GameObject SwordSlash = Instantiate(Slash, SlashPoint.transform.position, SlashPoint.transform.rotation);
        }
    }

    public override void Fire2(bool value)
    {
        if (CooldownTime1 <= Time.time)
        {
            BashRushPoint.SetActive(true);
            rb.AddForce(transform.forward * ChargeAttack);
        }
        
    }
    public override void Fire3(bool value)
    {
        if(CooldownTime2 <= Time.time)
        {
            GameObject AirShieldWall = Instantiate(AirShield, AirShieldPoint.transform.position, AirShieldPoint.transform.rotation);
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