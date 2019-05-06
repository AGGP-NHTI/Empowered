using System.Collections;
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

    private static bool CooldownTime0 = false;
    private bool CooldownTime1 = false;
    private bool CooldownTime2 = false;
    public static float cooldownPeriod0 = 1.0f;
    public static float cooldownPeriod1 = 19.0f;
    public static float cooldownPeriod2 = 33.0f;

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
        if (!MageClass.CooldownTime0)
        {
            GameObject FireBolt = Instantiate(Fire, FirePoint.transform.position, FirePoint.transform.rotation);
            MageClass.CooldownTime0 = true;
        }
        else
        {
            MageClass.cooldownPeriod0 -= Time.deltaTime;
            if (MageClass.cooldownPeriod0 <= 0)
            {
                MageClass.CooldownTime0 = false;
            }
        }
    }

    public override void Fire2(bool value)
    {
      //  if(CooldownTime1 <= Time.time)
        {
            GameObject LightningBolt = Instantiate(Lightning, LightningPoint.transform.position, LightningPoint.transform.rotation);
        }
    }
    public override void Fire3(bool value)
    {
       // if(CooldownTime2 <= Time.time)
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