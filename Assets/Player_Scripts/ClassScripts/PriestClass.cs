using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PriestClass : PlayerPawn
{
    public float MovementSpeed = 14;
    public float RotationSpeed = 280;

    public GameObject SacredGround;
    public GameObject SacredGroundPoint;
    public GameObject Holy;
    public GameObject HolyPoint;

    private float CooldownTime0;
    private float CooldownTime1;
    private float CooldownTime2;
    public float cooldownPeriod0 = 1.0f;
    public float cooldownPeriod1 = 25.0f;
    public float cooldownPeriod2 = 45.0f;

    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    
    Rigidbody rb;

    new void Start()
    {
        rb = GetComponent<Rigidbody>();
       
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    private void Update()
    {
        if (PriestHealth <= 0)
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
        if(CooldownTime0 <= cooldownPeriod0)
        {
            GameObject Smite = Instantiate(Holy, HolyPoint.transform.position, HolyPoint.transform.rotation);
        }
    }

    public override void Fire2(bool value)
    {
        if(CooldownTime1 <= cooldownPeriod1)
        {
            if (KnightHealth >= 420.0f || KnightHealth >= 350.0f)
            {
                KnightHealth = 420.0f;
            }
            else if (KnightHealth <= 350.0f)
            {
                KnightHealth += 70.0f;
            }

            if (RangerHealth >= 400.0f || KnightHealth >= 330.0f)
            {
                RangerHealth = 400.0f;
            }
            else if (RangerHealth <= 330.0f)
            {
                RangerHealth += 70.0f;
            }

            if (MageHealth >= 380.0f || MageHealth >= 310.0f)
            {
                MageHealth = 380.0f;
            }
            else if (MageHealth <= 310.0f)
            {
                MageHealth += 70.0f;
            }

            if (PriestHealth >= 380.0f || PriestHealth >= 310.0f)
            {
                PriestHealth = 365.0f;
            }
            else if (PriestHealth <= 310.0f)
            {
                PriestHealth += 70.0f;
            }
        }
        
    }
    public override void Fire3(bool value)
    {
        if(CooldownTime2 <= cooldownPeriod2)
        {
            GameObject Consecration = Instantiate(SacredGround, SacredGroundPoint.transform.position, SacredGroundPoint.transform.rotation);
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